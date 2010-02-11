using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using jabber.client;
using System.Threading;
using jabber.protocol.iq;
using jabber;
using Google.GData.Contacts;
using Google.GData.Extensions;
using jabber.protocol;
using System.Windows.Forms.Integration;
using muzzle;
using System.Collections;

namespace XmppClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        JabberClient jabberClient1 = new JabberClient();
        RosterManager rm;
        PresenceManager pm;
        int chatCount = -1;
        Hashtable chatIndex = new Hashtable();
        RosterTree rosterTree1 = new RosterTree();

        /*
        public Window1()
        {
            InitializeComponent();
            WindowsFormsHost fhost = new WindowsFormsHost();
            fhost.Child = rosterTree1;
            mainGrid.Children.Add(fhost);


            jabberClient1.OnMessage += new MessageHandler(jabberClient1_OnMessage);
            jabberClient1.OnDisconnect += new bedrock.ObjectHandler(jabberClient1_OnDisconnect);
            jabberClient1.OnError += new bedrock.ExceptionHandler(jabberClient1_OnError);
            jabberClient1.OnAuthError += new jabber.protocol.ProtocolHandler(jabberClient1_OnAuthError);

        }
       
        void jabberClient1_OnAuthError(object sender, System.Xml.XmlElement rp)
        {
            if (rp.Name == "failure")
            {
                MessageBox.Show("Invalid User Name or Password", "Error!!!");
                //pnlCredentials.Enabled = true;
                //txtUserName.SelectAll();
                //txtUserName.Focus();
            }
        }

        void jabberClient1_OnError(object sender, Exception ex)
        {
            MessageBox.Show(ex.Message, "Error!!!");
            //pnlCredentials.Enabled = true;
            //txtUserName.SelectAll();
            //txtUserName.Focus();
        }

        void jabberClient1_OnDisconnect(object sender)
        {
            //pnlContact.Visible = false;
            //pnlCredentials.Enabled = true;
            //pnlCredentials.Visible = true;
            //txtUserName.Focus();
        }

        private void jabberClient1_OnMessage(object sender, jabber.protocol.client.Message msg)
        {

            frmChat[(int)chatIndex[msg.From.Bare]].ReceiveFlag = true;
            string receivedMsg = msg.From.User + " Says : " + msg.Body + "\n";
            frmChat[(int)chatIndex[msg.From.Bare]].AppendConversation(receivedMsg);
            frmChat[(int)chatIndex[msg.From.Bare]].Show();
        }


        private void Connect()
        {
            jabberClient1.User = "baran@barisgorsel.com";
            jabberClient1.Password = "Yazilimci22726";
            jabberClient1.Server = "gmail.com";
            jabberClient1.AutoRoster = true;

            rm = new RosterManager();
            rm.Stream = jabberClient1;
            rm.AutoSubscribe = true;
            rm.AutoAllow = jabber.client.AutoSubscriptionHanding.AllowAll;
            rm.OnRosterBegin += new bedrock.ObjectHandler(rm_OnRosterBegin);
            rm.OnRosterEnd += new bedrock.ObjectHandler(rm_OnRosterEnd);
            rm.OnRosterItem += new RosterItemHandler(rm_OnRosterItem);


            pm = new PresenceManager();
            pm.Stream = jabberClient1;

            rosterTree1.RosterManager = rm;
            rosterTree1.PresenceManager = pm;
            rosterTree1.DoubleClick += new EventHandler(rosterTree1_DoubleClick);

            jabberClient1.Connect();
            jabberClient1.OnAuthenticate += new bedrock.ObjectHandler(jabberClient1_OnAuthenticate);
            //lblUser.Text = jabberClient1.User;
        }
        void rm_OnRosterItem(object sender, Item ri)
        {
            try
            {
                chatIndex.Add(ri.JID.Bare, ++chatCount);
                InitializeFrmChat(ri.JID.Bare, ri.Nickname);
            }
            catch { }
        }

        void rosterTree1_DoubleClick(object sender, EventArgs e)
        {
            muzzle.RosterTree.ItemNode selectedNode = rosterTree1.SelectedNode as muzzle.RosterTree.ItemNode;
            if (selectedNode != null)
                frmChat[(int)chatIndex[selectedNode.JID.Bare]].Show();
        }


        void rm_OnRosterBegin(object sender)
        {
            frmChat = new FrmChat[500];
            chatIndex = new Hashtable();
            rosterTree1.BeginUpdate();
        }

        void rm_OnRosterEnd(object sender)
        {
            RosterManager rm1 = (RosterManager)sender;
            done.Set();
            rosterTree1.EndUpdate();
            jabberClient1.Presence(jabber.protocol.client.PresenceType.available, tbStatus.Text, null, 0);
            lblPresence.Text = "Available";
            rosterTree1.ExpandAll();
        }

        void jabberClient1_OnAuthenticate(object sender)
        {
            pnlCredentials.Visible = false;
            pnlContact.Visible = true;
            done.Set();
            tbStatus.Text = "";
            txtPassword.Text = "";
        }*/

    }
}
