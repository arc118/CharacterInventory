using System;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;


namespace Character_Inventory
{
    public partial class Form_ContainerView : Form
    {
        //Event Handler for Key Press Items in ListBoxes
        public delegate void KeyDown_EventHander(object sender, KeyEventArgs keypress);
        public delegate void KeyPress_EventHandler(object sender, KeyEventArgs keypress);

        public Form_ContainerView()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void button_closeWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Open Elanthipedia with search page when user hits the Enter Key on this form
        private void treeView_Container_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            TreeView the_item = (TreeView)sender;

            string keyValue = e.KeyCode.ToString();

            if (keyValue == Keys.Enter.ToString())
            {

                e.Handled = true;
                e.SuppressKeyPress = true;

                if (the_item is TreeView)
                {
                    //MessageBox.Show(the_item.SelectedNode.Text);
                    if (the_item != null)
                    {
                        string temp_string = the_item.SelectedNode.Text;

                        string updated_string = string.Join(" ", temp_string.Split().Skip(1));

                        string url_string = "https://elanthipedia.play.net/index.php?search=" + updated_string;

                        try
                        {
                            System.Diagnostics.Process.Start(url_string);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Unable to open the default browser.");
                        //}
                        
                            // hack because of this: https://github.com/dotnet/corefx/issues/10361
                            if (Environment.OSVersion.Version.Major >= 6)
                            {

                                url_string = url_string.Replace("&", "^&");
                                url_string = url_string.Replace(" ", "%20");
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/k start {url_string}") { CreateNoWindow = true });
                            }
                            else
                            {
                              MessageBox.Show("Unable to open the default browser. If running in Linux or OSX, this is not currently compatible.");
                            }
                        }
                        





                    }

                }
            }

        }

        //Suppress sound on hitting Enter Key - god that was annoying
        private void treeView_Container_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;

        }

    }
}
