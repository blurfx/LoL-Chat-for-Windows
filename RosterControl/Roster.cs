using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using jabber.client;
using jabber.protocol.iq;
using bedrock.collections;
using System.Collections;
using jabber.protocol.client;
using jabber;
using muzzle;
namespace LoLChat_for_Windows
{
    public partial class Roster : TreeView
    {
        private RosterManager m_roster = null;
        private PresenceManager m_pres = null;

        private IDictionary m_groups = new SkipList();
        private IDictionary m_items = new SkipList();

        public Roster()
        {
            InitializeComponent();
        }

        private const string UNFILED = "지정되지 않음";

        [Category("Managers")]
        public RosterManager RosterManager
        {
            get
            {
                // If we are running in the designer, let's try to auto-hook a RosterManager
                if ((m_roster == null) && DesignMode)
                {
                    IDesignerHost host = (IDesignerHost)base.GetService(typeof(IDesignerHost));
                    this.RosterManager = (RosterManager)jabber.connection.StreamComponent.GetComponentFromHost(host, typeof(RosterManager));
                }
                return m_roster;
            }
            set
            {
                if ((object)m_roster == (object)value)
                    return;
                m_roster = value;
                if (m_roster != null)
                {
                    m_roster.OnRosterBegin += new bedrock.ObjectHandler(m_roster_OnRosterBegin);
                    m_roster.OnRosterEnd += new bedrock.ObjectHandler(m_roster_OnRosterEnd);
                    m_roster.OnRosterItem += new RosterItemHandler(m_roster_OnRosterItem);
                }
            }
        }


        private void m_roster_OnRosterBegin(object sender)
        {
            this.BeginUpdate();
        }

        private void m_roster_OnRosterEnd(object sender)
        {
            this.EndUpdate();
        }

        private void m_roster_OnRosterItem(object sender, jabber.protocol.iq.Item ri)
        {
            bool remove = (ri.Subscription == Subscription.remove);

            LinkedList nodelist = (LinkedList)m_items[ri.JID.ToString()];
            if (nodelist == null)
            {
                // First time through.
                if (!remove)
                {
                    nodelist = new LinkedList();
                    m_items.Add(ri.JID.ToString(), nodelist);
                }
            }
            else
            {
                // update to an existing item.  remove all of them, and start over.
                foreach (muzzle.RosterTree.ItemNode i in nodelist)
                {
                    muzzle.RosterTree.GroupNode gn = i.Parent as muzzle.RosterTree.GroupNode;
                    i.Remove();
                    if ((gn != null) && (gn.Nodes.Count == 0))
                    {
                        m_groups.Remove(gn.GroupName);
                        gn.Remove();
                    }
                }
                nodelist.Clear();
                if (remove)
                    m_items.Remove(ri.JID.ToString());
            }

            if (remove)
                return;

            // add the new ones back
            Hashtable ghash = new Hashtable();
            Group[] groups = ri.GetGroups();
            for (int i = groups.Length - 1; i >= 0; i--)
            {
                if (groups[i].GroupName == "")
                    groups[i].GroupName = UNFILED;
            }

            if (groups.Length == 0)
            {
                groups = new Group[] { new Group(ri.OwnerDocument) };
                groups[0].GroupName = UNFILED;
            }

            foreach (Group g in groups)
            {
                muzzle.RosterTree.GroupNode gn = AddGroupNode(g);
                // might have the same group twice.
                if (ghash.Contains(g.GroupName))
                    continue;
                ghash.Add(g.GroupName, g);

                muzzle.RosterTree.ItemNode i = new muzzle.RosterTree.ItemNode(ri);
                i.ChangePresence(m_pres[ri.JID]);
                nodelist.Add(i);
                gn.Nodes.Add(i);
            }
        }


        private muzzle.RosterTree.GroupNode AddGroupNode(Group g)
        {
            muzzle.RosterTree.GroupNode gn = (muzzle.RosterTree.GroupNode)m_groups[g.GroupName];
            if (gn == null)
            {
                gn = new muzzle.RosterTree.GroupNode(g);
                m_groups.Add(g.GroupName, gn);
                this.Nodes.Add(gn);
            }
            return gn;

        }
        /// <summary>
        /// The PresenceManager for this view
        /// </summary>
        [Category("Managers")]
        public PresenceManager PresenceManager
        {
            get
            {
                // If we are running in the designer, let's try to auto-hook a PresenceManager
                if ((m_pres == null) && DesignMode)
                {
                    IDesignerHost host = (IDesignerHost)base.GetService(typeof(IDesignerHost));
                    this.PresenceManager = (PresenceManager)jabber.connection.StreamComponent.GetComponentFromHost(host, typeof(PresenceManager));
                }
                return m_pres;
            }
            set
            {
                if ((object)m_pres == (object)value)
                    return;
                m_pres = value;
                if (m_pres != null)
                    m_pres.OnPrimarySessionChange += new PrimarySessionHandler(m_pres_OnPrimarySessionChange);
            }
        }

        private void m_pres_OnPrimarySessionChange(object sender, JID bare)
        {
            Presence pres = m_pres[bare];
            LinkedList nodelist = (LinkedList)m_items[bare.ToString()];
            if (nodelist == null)
                return;

            foreach (muzzle.RosterTree.ItemNode n in nodelist)
            {
                n.ChangePresence(pres);
            }
        }
    }
}
