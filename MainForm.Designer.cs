using System;

namespace Character_Inventory
{
    /************************************************************/
    /* Do not change this unless you understand Windows Forms   */
    /* This is where the code for the Form you design is stored */
    /* This will be automatically updated when you make changes */
    /* in the Designer view for form (aka Pop-up Window)        */
    /************************************************************/

    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_closewindow = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.listBox_body = new System.Windows.Forms.ListBox();
            this.listBox_head = new System.Windows.Forms.ListBox();
            this.groupBox_Head = new System.Windows.Forms.GroupBox();
            this.listBox_neck = new System.Windows.Forms.ListBox();
            this.listBox_nose = new System.Windows.Forms.ListBox();
            this.listBox_bothEars = new System.Windows.Forms.ListBox();
            this.listBox_ear = new System.Windows.Forms.ListBox();
            this.listBox_righteye = new System.Windows.Forms.ListBox();
            this.listBox_leftEye = new System.Windows.Forms.ListBox();
            this.listBox_hairPlaced = new System.Windows.Forms.ListBox();
            this.listBox_hairTied = new System.Windows.Forms.ListBox();
            this.listBox_headArmor = new System.Windows.Forms.ListBox();
            this.groupBox_Arms = new System.Windows.Forms.GroupBox();
            this.listBox_parryStick = new System.Windows.Forms.ListBox();
            this.listBox_shieldWorn = new System.Windows.Forms.ListBox();
            this.listBox_elbowWeapon = new System.Windows.Forms.ListBox();
            this.listBox_armArmor = new System.Windows.Forms.ListBox();
            this.listBox_armUpper = new System.Windows.Forms.ListBox();
            this.groupBox_Legs = new System.Windows.Forms.GroupBox();
            this.listBox_feet = new System.Windows.Forms.ListBox();
            this.listBox_footWeapon = new System.Windows.Forms.ListBox();
            this.listBox_ankle = new System.Windows.Forms.ListBox();
            this.listBox_kneeWeapon = new System.Windows.Forms.ListBox();
            this.listBox_thigh = new System.Windows.Forms.ListBox();
            this.listBox_legArmor = new System.Windows.Forms.ListBox();
            this.listBox_pants = new System.Windows.Forms.ListBox();
            this.groupBox_Body = new System.Windows.Forms.GroupBox();
            this.listBox_tail = new System.Windows.Forms.ListBox();
            this.listBox_shirt = new System.Windows.Forms.ListBox();
            this.listBox_shirtArmor = new System.Windows.Forms.ListBox();
            this.groupBox_Waist = new System.Windows.Forms.GroupBox();
            this.listBox_belt = new System.Windows.Forms.ListBox();
            this.listBox_waist = new System.Windows.Forms.ListBox();
            this.groupBox_Back = new System.Windows.Forms.GroupBox();
            this.listBox_back = new System.Windows.Forms.ListBox();
            this.listBox_shouldersOver = new System.Windows.Forms.ListBox();
            this.listBox_shouldersOn = new System.Windows.Forms.ListBox();
            this.groupBox_Ground = new System.Windows.Forms.GroupBox();
            this.listBox_atFeet = new System.Windows.Forms.ListBox();
            this.comboBox_CharacterSelect = new System.Windows.Forms.ComboBox();
            this.button_scanInventory = new System.Windows.Forms.Button();
            this.groupBox_hands = new System.Windows.Forms.GroupBox();
            this.listBox_fingers = new System.Windows.Forms.ListBox();
            this.listBox_wrist = new System.Windows.Forms.ListBox();
            this.listBox_handWeapon = new System.Windows.Forms.ListBox();
            this.listBox_hands = new System.Windows.Forms.ListBox();
            this.pictureBox_male = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_Slots_Head = new System.Windows.Forms.Label();
            this.label_Slots_headArmor = new System.Windows.Forms.Label();
            this.label_Slots_hairTied = new System.Windows.Forms.Label();
            this.label_Slots_hairPlaced = new System.Windows.Forms.Label();
            this.label_Slots_leftEye = new System.Windows.Forms.Label();
            this.label_Slots_rightEye = new System.Windows.Forms.Label();
            this.label_Slots_ear = new System.Windows.Forms.Label();
            this.label_Slots_bothEars = new System.Windows.Forms.Label();
            this.label_Slots_nose = new System.Windows.Forms.Label();
            this.label_Slots_neck = new System.Windows.Forms.Label();
            this.label_Slots_shouldersOn = new System.Windows.Forms.Label();
            this.label_Slots_shouldersOver = new System.Windows.Forms.Label();
            this.label_Slots_back = new System.Windows.Forms.Label();
            this.label_Slots_hands = new System.Windows.Forms.Label();
            this.label_Slots_handWeapon = new System.Windows.Forms.Label();
            this.label_Slots_wrist = new System.Windows.Forms.Label();
            this.label_Slots_fingers = new System.Windows.Forms.Label();
            this.label_Slots_pants = new System.Windows.Forms.Label();
            this.label_Slots_legArmor = new System.Windows.Forms.Label();
            this.label_Slots_thigh = new System.Windows.Forms.Label();
            this.label_Slots_kneeWeapon = new System.Windows.Forms.Label();
            this.label_Slots_ankle = new System.Windows.Forms.Label();
            this.label_Slots_footWeapon = new System.Windows.Forms.Label();
            this.label_Slots_feet = new System.Windows.Forms.Label();
            this.label_Slots_armUpper = new System.Windows.Forms.Label();
            this.label_Slots_armArmor = new System.Windows.Forms.Label();
            this.label_Slots_elbowWeapon = new System.Windows.Forms.Label();
            this.label_Slots_shieldWorn = new System.Windows.Forms.Label();
            this.label_Slots_parryStick = new System.Windows.Forms.Label();
            this.label_Slots_body = new System.Windows.Forms.Label();
            this.label_Slots_shirtArmor = new System.Windows.Forms.Label();
            this.label_Slots_shirt = new System.Windows.Forms.Label();
            this.label_Slots_waist = new System.Windows.Forms.Label();
            this.label_Slots_belt = new System.Windows.Forms.Label();
            this.label_Slots_ground = new System.Windows.Forms.Label();
            this.label_Slots_tail = new System.Windows.Forms.Label();
            this.label_youAreWearing = new System.Windows.Forms.Label();
            this.label_totalWorn = new System.Windows.Forms.Label();
            this.label_itemLocation = new System.Windows.Forms.Label();
            this.label_locationText = new System.Windows.Forms.Label();
            this.button_scanContainer = new System.Windows.Forms.Button();
            this.checkBox_showContainers = new System.Windows.Forms.CheckBox();
            this.groupBox_Head.SuspendLayout();
            this.groupBox_Arms.SuspendLayout();
            this.groupBox_Legs.SuspendLayout();
            this.groupBox_Body.SuspendLayout();
            this.groupBox_Waist.SuspendLayout();
            this.groupBox_Back.SuspendLayout();
            this.groupBox_Ground.SuspendLayout();
            this.groupBox_hands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_male)).BeginInit();
            this.SuspendLayout();
            // 
            // button_closewindow
            // 
            this.button_closewindow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_closewindow.Location = new System.Drawing.Point(604, 801);
            this.button_closewindow.Name = "button_closewindow";
            this.button_closewindow.Size = new System.Drawing.Size(126, 27);
            this.button_closewindow.TabIndex = 0;
            this.button_closewindow.Text = "Close Window";
            this.button_closewindow.UseVisualStyleBackColor = true;
            this.button_closewindow.Click += new System.EventHandler(this.button_CloseWindow_Click);
            // 
            // label_title
            // 
            this.label_title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(210, 12);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(182, 24);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "Character Inventory: ";
            // 
            // listBox_body
            // 
            this.listBox_body.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_body.FormattingEnabled = true;
            this.listBox_body.HorizontalScrollbar = true;
            this.listBox_body.ItemHeight = 16;
            this.listBox_body.Location = new System.Drawing.Point(10, 32);
            this.listBox_body.Name = "listBox_body";
            this.listBox_body.Size = new System.Drawing.Size(336, 132);
            this.listBox_body.TabIndex = 4;
            this.listBox_body.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_body_MouseDoubleClick);
            this.listBox_body.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_body.MouseHover += new System.EventHandler(this.listBox_body_OnMouseOver);
            // 
            // listBox_head
            // 
            this.listBox_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_head.FormattingEnabled = true;
            this.listBox_head.HorizontalScrollbar = true;
            this.listBox_head.ItemHeight = 16;
            this.listBox_head.Location = new System.Drawing.Point(6, 35);
            this.listBox_head.Name = "listBox_head";
            this.listBox_head.Size = new System.Drawing.Size(295, 36);
            this.listBox_head.TabIndex = 5;
            this.listBox_head.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_head_MouseDoubleClick);
            this.listBox_head.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_head.MouseHover += new System.EventHandler(this.listBox_head_OnMouseOver);
            // 
            // groupBox_Head
            // 
            this.groupBox_Head.AutoSize = true;
            this.groupBox_Head.Controls.Add(this.listBox_neck);
            this.groupBox_Head.Controls.Add(this.listBox_nose);
            this.groupBox_Head.Controls.Add(this.listBox_bothEars);
            this.groupBox_Head.Controls.Add(this.listBox_ear);
            this.groupBox_Head.Controls.Add(this.listBox_righteye);
            this.groupBox_Head.Controls.Add(this.listBox_leftEye);
            this.groupBox_Head.Controls.Add(this.listBox_hairPlaced);
            this.groupBox_Head.Controls.Add(this.listBox_hairTied);
            this.groupBox_Head.Controls.Add(this.listBox_headArmor);
            this.groupBox_Head.Controls.Add(this.listBox_head);
            this.groupBox_Head.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Head.Location = new System.Drawing.Point(16, 12);
            this.groupBox_Head.Name = "groupBox_Head";
            this.groupBox_Head.Size = new System.Drawing.Size(307, 639);
            this.groupBox_Head.TabIndex = 6;
            this.groupBox_Head.TabStop = false;
            this.groupBox_Head.Text = "Head";
            // 
            // listBox_neck
            // 
            this.listBox_neck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_neck.FormattingEnabled = true;
            this.listBox_neck.HorizontalScrollbar = true;
            this.listBox_neck.ItemHeight = 16;
            this.listBox_neck.Location = new System.Drawing.Point(6, 368);
            this.listBox_neck.Name = "listBox_neck";
            this.listBox_neck.Size = new System.Drawing.Size(295, 52);
            this.listBox_neck.TabIndex = 14;
            this.listBox_neck.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_neck_MouseDoubleClick);
            this.listBox_neck.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_neck.MouseHover += new System.EventHandler(this.listBox_neck_OnMouseOver);
            // 
            // listBox_nose
            // 
            this.listBox_nose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_nose.FormattingEnabled = true;
            this.listBox_nose.HorizontalScrollbar = true;
            this.listBox_nose.ItemHeight = 16;
            this.listBox_nose.Location = new System.Drawing.Point(6, 331);
            this.listBox_nose.Name = "listBox_nose";
            this.listBox_nose.Size = new System.Drawing.Size(295, 36);
            this.listBox_nose.TabIndex = 14;
            this.listBox_nose.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_nose_MouseDoubleClick);
            this.listBox_nose.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_nose.MouseHover += new System.EventHandler(this.listBox_nose_OnMouseOver);
            // 
            // listBox_bothEars
            // 
            this.listBox_bothEars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_bothEars.FormattingEnabled = true;
            this.listBox_bothEars.ItemHeight = 16;
            this.listBox_bothEars.Location = new System.Drawing.Point(6, 294);
            this.listBox_bothEars.Name = "listBox_bothEars";
            this.listBox_bothEars.Size = new System.Drawing.Size(295, 36);
            this.listBox_bothEars.TabIndex = 14;
            this.listBox_bothEars.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_bothEars_MouseDoubleClick);
            this.listBox_bothEars.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_bothEars.MouseHover += new System.EventHandler(this.listBox_bothEars_OnMouseOver);
            // 
            // listBox_ear
            // 
            this.listBox_ear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_ear.FormattingEnabled = true;
            this.listBox_ear.ItemHeight = 16;
            this.listBox_ear.Location = new System.Drawing.Point(6, 257);
            this.listBox_ear.Name = "listBox_ear";
            this.listBox_ear.Size = new System.Drawing.Size(295, 36);
            this.listBox_ear.TabIndex = 14;
            this.listBox_ear.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_ear_MouseDoubleClick);
            this.listBox_ear.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_ear.MouseHover += new System.EventHandler(this.listBox_ear_OnMouseOver);
            // 
            // listBox_righteye
            // 
            this.listBox_righteye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_righteye.FormattingEnabled = true;
            this.listBox_righteye.HorizontalScrollbar = true;
            this.listBox_righteye.ItemHeight = 16;
            this.listBox_righteye.Location = new System.Drawing.Point(6, 220);
            this.listBox_righteye.Name = "listBox_righteye";
            this.listBox_righteye.Size = new System.Drawing.Size(295, 36);
            this.listBox_righteye.TabIndex = 14;
            this.listBox_righteye.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_rightEye_MouseDoubleClick);
            this.listBox_righteye.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_righteye.MouseHover += new System.EventHandler(this.listBox_righteye_OnMouseOver);
            // 
            // listBox_leftEye
            // 
            this.listBox_leftEye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_leftEye.FormattingEnabled = true;
            this.listBox_leftEye.HorizontalScrollbar = true;
            this.listBox_leftEye.ItemHeight = 16;
            this.listBox_leftEye.Location = new System.Drawing.Point(6, 183);
            this.listBox_leftEye.Name = "listBox_leftEye";
            this.listBox_leftEye.Size = new System.Drawing.Size(295, 36);
            this.listBox_leftEye.TabIndex = 14;
            this.listBox_leftEye.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_leftEye_MouseDoubleClick);
            this.listBox_leftEye.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_leftEye.MouseHover += new System.EventHandler(this.listBox_leftEye_OnMouseOver);
            // 
            // listBox_hairPlaced
            // 
            this.listBox_hairPlaced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_hairPlaced.FormattingEnabled = true;
            this.listBox_hairPlaced.HorizontalScrollbar = true;
            this.listBox_hairPlaced.ItemHeight = 16;
            this.listBox_hairPlaced.Location = new System.Drawing.Point(6, 146);
            this.listBox_hairPlaced.Name = "listBox_hairPlaced";
            this.listBox_hairPlaced.Size = new System.Drawing.Size(295, 36);
            this.listBox_hairPlaced.TabIndex = 14;
            this.listBox_hairPlaced.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_hairPlaced_MouseDoubleClick);
            this.listBox_hairPlaced.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_hairPlaced.MouseHover += new System.EventHandler(this.listBox_hairPlaced_OnMouseOver);
            // 
            // listBox_hairTied
            // 
            this.listBox_hairTied.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_hairTied.FormattingEnabled = true;
            this.listBox_hairTied.HorizontalScrollbar = true;
            this.listBox_hairTied.ItemHeight = 16;
            this.listBox_hairTied.Location = new System.Drawing.Point(6, 109);
            this.listBox_hairTied.Name = "listBox_hairTied";
            this.listBox_hairTied.Size = new System.Drawing.Size(295, 36);
            this.listBox_hairTied.TabIndex = 14;
            this.listBox_hairTied.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_hairTied_MouseDoubleClick);
            this.listBox_hairTied.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_hairTied.MouseHover += new System.EventHandler(this.listBox_hairTied_OnMouseOver);
            // 
            // listBox_headArmor
            // 
            this.listBox_headArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_headArmor.FormattingEnabled = true;
            this.listBox_headArmor.HorizontalScrollbar = true;
            this.listBox_headArmor.ItemHeight = 16;
            this.listBox_headArmor.Location = new System.Drawing.Point(6, 72);
            this.listBox_headArmor.Name = "listBox_headArmor";
            this.listBox_headArmor.Size = new System.Drawing.Size(295, 36);
            this.listBox_headArmor.TabIndex = 14;
            this.listBox_headArmor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_headArmor_MouseDoubleClick);
            this.listBox_headArmor.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_headArmor.MouseHover += new System.EventHandler(this.listBox_headArmor_OnMouseOver);
            // 
            // groupBox_Arms
            // 
            this.groupBox_Arms.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox_Arms.AutoSize = true;
            this.groupBox_Arms.Controls.Add(this.listBox_parryStick);
            this.groupBox_Arms.Controls.Add(this.listBox_shieldWorn);
            this.groupBox_Arms.Controls.Add(this.listBox_elbowWeapon);
            this.groupBox_Arms.Controls.Add(this.listBox_armArmor);
            this.groupBox_Arms.Controls.Add(this.listBox_armUpper);
            this.groupBox_Arms.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Arms.Location = new System.Drawing.Point(736, 12);
            this.groupBox_Arms.Name = "groupBox_Arms";
            this.groupBox_Arms.Size = new System.Drawing.Size(353, 272);
            this.groupBox_Arms.TabIndex = 7;
            this.groupBox_Arms.TabStop = false;
            this.groupBox_Arms.Text = "Arms";
            // 
            // listBox_parryStick
            // 
            this.listBox_parryStick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_parryStick.FormattingEnabled = true;
            this.listBox_parryStick.ItemHeight = 16;
            this.listBox_parryStick.Location = new System.Drawing.Point(6, 208);
            this.listBox_parryStick.Name = "listBox_parryStick";
            this.listBox_parryStick.Size = new System.Drawing.Size(340, 36);
            this.listBox_parryStick.TabIndex = 4;
            this.listBox_parryStick.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_parryStick_MouseDoubleClick);
            this.listBox_parryStick.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_parryStick.MouseHover += new System.EventHandler(this.listBox_parryStick_OnMouseOver);
            // 
            // listBox_shieldWorn
            // 
            this.listBox_shieldWorn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_shieldWorn.FormattingEnabled = true;
            this.listBox_shieldWorn.ItemHeight = 16;
            this.listBox_shieldWorn.Location = new System.Drawing.Point(6, 170);
            this.listBox_shieldWorn.Name = "listBox_shieldWorn";
            this.listBox_shieldWorn.Size = new System.Drawing.Size(340, 36);
            this.listBox_shieldWorn.TabIndex = 3;
            this.listBox_shieldWorn.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_shieldWorn_MouseDoubleClick);
            this.listBox_shieldWorn.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_shieldWorn.MouseHover += new System.EventHandler(this.listBox_shieldWorn_OnMouseOver);
            // 
            // listBox_elbowWeapon
            // 
            this.listBox_elbowWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_elbowWeapon.FormattingEnabled = true;
            this.listBox_elbowWeapon.ItemHeight = 16;
            this.listBox_elbowWeapon.Location = new System.Drawing.Point(6, 132);
            this.listBox_elbowWeapon.Name = "listBox_elbowWeapon";
            this.listBox_elbowWeapon.Size = new System.Drawing.Size(340, 36);
            this.listBox_elbowWeapon.TabIndex = 2;
            this.listBox_elbowWeapon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_elbowWeapon_MouseDoubleClick);
            this.listBox_elbowWeapon.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_elbowWeapon.MouseHover += new System.EventHandler(this.listBox_elbowWeapon_OnMouseOver);
            // 
            // listBox_armArmor
            // 
            this.listBox_armArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_armArmor.FormattingEnabled = true;
            this.listBox_armArmor.ItemHeight = 16;
            this.listBox_armArmor.Location = new System.Drawing.Point(6, 94);
            this.listBox_armArmor.Name = "listBox_armArmor";
            this.listBox_armArmor.Size = new System.Drawing.Size(340, 36);
            this.listBox_armArmor.TabIndex = 1;
            this.listBox_armArmor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_armArmor_MouseDoubleClick);
            this.listBox_armArmor.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_armArmor.MouseHover += new System.EventHandler(this.listBox_armArmor_OnMouseOver);
            // 
            // listBox_armUpper
            // 
            this.listBox_armUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_armUpper.FormattingEnabled = true;
            this.listBox_armUpper.HorizontalScrollbar = true;
            this.listBox_armUpper.ItemHeight = 16;
            this.listBox_armUpper.Location = new System.Drawing.Point(6, 24);
            this.listBox_armUpper.Name = "listBox_armUpper";
            this.listBox_armUpper.Size = new System.Drawing.Size(340, 68);
            this.listBox_armUpper.TabIndex = 0;
            this.listBox_armUpper.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_armUpper_MouseDoubleClick);
            this.listBox_armUpper.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_armUpper.MouseHover += new System.EventHandler(this.listBox_armUpper_OnMouseOver);
            // 
            // groupBox_Legs
            // 
            this.groupBox_Legs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox_Legs.AutoSize = true;
            this.groupBox_Legs.Controls.Add(this.listBox_feet);
            this.groupBox_Legs.Controls.Add(this.listBox_footWeapon);
            this.groupBox_Legs.Controls.Add(this.listBox_ankle);
            this.groupBox_Legs.Controls.Add(this.listBox_kneeWeapon);
            this.groupBox_Legs.Controls.Add(this.listBox_thigh);
            this.groupBox_Legs.Controls.Add(this.listBox_legArmor);
            this.groupBox_Legs.Controls.Add(this.listBox_pants);
            this.groupBox_Legs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Legs.Location = new System.Drawing.Point(381, 281);
            this.groupBox_Legs.Name = "groupBox_Legs";
            this.groupBox_Legs.Size = new System.Drawing.Size(308, 405);
            this.groupBox_Legs.TabIndex = 8;
            this.groupBox_Legs.TabStop = false;
            this.groupBox_Legs.Text = "Legs";
            // 
            // listBox_feet
            // 
            this.listBox_feet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_feet.FormattingEnabled = true;
            this.listBox_feet.HorizontalScrollbar = true;
            this.listBox_feet.ItemHeight = 16;
            this.listBox_feet.Location = new System.Drawing.Point(7, 341);
            this.listBox_feet.Name = "listBox_feet";
            this.listBox_feet.Size = new System.Drawing.Size(295, 36);
            this.listBox_feet.TabIndex = 16;
            this.listBox_feet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_feet_MouseDoubleClick);
            this.listBox_feet.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_feet.MouseHover += new System.EventHandler(this.listBox_feet_OnMouseOver);
            // 
            // listBox_footWeapon
            // 
            this.listBox_footWeapon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox_footWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_footWeapon.FormattingEnabled = true;
            this.listBox_footWeapon.HorizontalScrollbar = true;
            this.listBox_footWeapon.ItemHeight = 16;
            this.listBox_footWeapon.Location = new System.Drawing.Point(6, 303);
            this.listBox_footWeapon.Name = "listBox_footWeapon";
            this.listBox_footWeapon.Size = new System.Drawing.Size(295, 36);
            this.listBox_footWeapon.TabIndex = 5;
            this.listBox_footWeapon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_footWeapon_MouseDoubleClick);
            this.listBox_footWeapon.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_footWeapon.MouseHover += new System.EventHandler(this.listBox_footWeapon_OnMouseOver);
            // 
            // listBox_ankle
            // 
            this.listBox_ankle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_ankle.FormattingEnabled = true;
            this.listBox_ankle.HorizontalScrollbar = true;
            this.listBox_ankle.ItemHeight = 16;
            this.listBox_ankle.Location = new System.Drawing.Point(6, 233);
            this.listBox_ankle.Name = "listBox_ankle";
            this.listBox_ankle.Size = new System.Drawing.Size(295, 68);
            this.listBox_ankle.TabIndex = 4;
            this.listBox_ankle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_ankle_MouseDoubleClick);
            this.listBox_ankle.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_ankle.MouseHover += new System.EventHandler(this.listBox_ankle_OnMouseOver);
            // 
            // listBox_kneeWeapon
            // 
            this.listBox_kneeWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_kneeWeapon.FormattingEnabled = true;
            this.listBox_kneeWeapon.HorizontalScrollbar = true;
            this.listBox_kneeWeapon.ItemHeight = 16;
            this.listBox_kneeWeapon.Location = new System.Drawing.Point(7, 194);
            this.listBox_kneeWeapon.Name = "listBox_kneeWeapon";
            this.listBox_kneeWeapon.Size = new System.Drawing.Size(295, 36);
            this.listBox_kneeWeapon.TabIndex = 3;
            this.listBox_kneeWeapon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_kneeWeapon_MouseDoubleClick);
            this.listBox_kneeWeapon.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_kneeWeapon.MouseHover += new System.EventHandler(this.listBox_kneeWeapon_OnMouseOver);
            // 
            // listBox_thigh
            // 
            this.listBox_thigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_thigh.FormattingEnabled = true;
            this.listBox_thigh.HorizontalScrollbar = true;
            this.listBox_thigh.ItemHeight = 16;
            this.listBox_thigh.Location = new System.Drawing.Point(6, 123);
            this.listBox_thigh.Name = "listBox_thigh";
            this.listBox_thigh.Size = new System.Drawing.Size(295, 68);
            this.listBox_thigh.TabIndex = 2;
            this.listBox_thigh.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_thigh_MouseDoubleClick);
            this.listBox_thigh.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_thigh.MouseHover += new System.EventHandler(this.listBox_thigh_OnMouseOver);
            // 
            // listBox_legArmor
            // 
            this.listBox_legArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_legArmor.FormattingEnabled = true;
            this.listBox_legArmor.HorizontalScrollbar = true;
            this.listBox_legArmor.ItemHeight = 16;
            this.listBox_legArmor.Location = new System.Drawing.Point(6, 84);
            this.listBox_legArmor.Name = "listBox_legArmor";
            this.listBox_legArmor.Size = new System.Drawing.Size(295, 36);
            this.listBox_legArmor.TabIndex = 1;
            this.listBox_legArmor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_legArmor_MouseDoubleClick);
            this.listBox_legArmor.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_legArmor.MouseHover += new System.EventHandler(this.listBox_legArmor_OnMouseOver);
            // 
            // listBox_pants
            // 
            this.listBox_pants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_pants.FormattingEnabled = true;
            this.listBox_pants.HorizontalScrollbar = true;
            this.listBox_pants.ItemHeight = 16;
            this.listBox_pants.Location = new System.Drawing.Point(6, 45);
            this.listBox_pants.Name = "listBox_pants";
            this.listBox_pants.Size = new System.Drawing.Size(295, 36);
            this.listBox_pants.TabIndex = 0;
            this.listBox_pants.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_pants_MouseDoubleClick);
            this.listBox_pants.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_pants.MouseHover += new System.EventHandler(this.listBox_pants_OnMouseOver);
            // 
            // groupBox_Body
            // 
            this.groupBox_Body.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox_Body.AutoSize = true;
            this.groupBox_Body.Controls.Add(this.listBox_tail);
            this.groupBox_Body.Controls.Add(this.listBox_shirt);
            this.groupBox_Body.Controls.Add(this.listBox_shirtArmor);
            this.groupBox_Body.Controls.Add(this.listBox_body);
            this.groupBox_Body.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Body.Location = new System.Drawing.Point(736, 290);
            this.groupBox_Body.Name = "groupBox_Body";
            this.groupBox_Body.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox_Body.Size = new System.Drawing.Size(353, 336);
            this.groupBox_Body.TabIndex = 9;
            this.groupBox_Body.TabStop = false;
            this.groupBox_Body.Text = "Body";
            // 
            // listBox_tail
            // 
            this.listBox_tail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_tail.FormattingEnabled = true;
            this.listBox_tail.ItemHeight = 16;
            this.listBox_tail.Location = new System.Drawing.Point(10, 259);
            this.listBox_tail.Name = "listBox_tail";
            this.listBox_tail.Size = new System.Drawing.Size(336, 52);
            this.listBox_tail.TabIndex = 7;
            this.listBox_tail.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_tail_MouseDoubleClick);
            this.listBox_tail.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_tail.MouseHover += new System.EventHandler(this.listBox_tail_OnMouseOver);
            // 
            // listBox_shirt
            // 
            this.listBox_shirt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_shirt.FormattingEnabled = true;
            this.listBox_shirt.HorizontalScrollbar = true;
            this.listBox_shirt.ItemHeight = 16;
            this.listBox_shirt.Location = new System.Drawing.Point(10, 221);
            this.listBox_shirt.Name = "listBox_shirt";
            this.listBox_shirt.Size = new System.Drawing.Size(336, 36);
            this.listBox_shirt.TabIndex = 6;
            this.listBox_shirt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_shirt_MouseDoubleClick);
            this.listBox_shirt.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_shirt.MouseHover += new System.EventHandler(this.listBox_shirt_OnMouseOver);
            // 
            // listBox_shirtArmor
            // 
            this.listBox_shirtArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_shirtArmor.FormattingEnabled = true;
            this.listBox_shirtArmor.HorizontalScrollbar = true;
            this.listBox_shirtArmor.ItemHeight = 16;
            this.listBox_shirtArmor.Location = new System.Drawing.Point(10, 167);
            this.listBox_shirtArmor.Name = "listBox_shirtArmor";
            this.listBox_shirtArmor.Size = new System.Drawing.Size(336, 52);
            this.listBox_shirtArmor.TabIndex = 5;
            this.listBox_shirtArmor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_shirtArmor_MouseDoubleClick);
            this.listBox_shirtArmor.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_shirtArmor.MouseHover += new System.EventHandler(this.listBox_shirtArmor_OnMouseOver);
            // 
            // groupBox_Waist
            // 
            this.groupBox_Waist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Waist.AutoSize = true;
            this.groupBox_Waist.Controls.Add(this.listBox_belt);
            this.groupBox_Waist.Controls.Add(this.listBox_waist);
            this.groupBox_Waist.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Waist.Location = new System.Drawing.Point(736, 632);
            this.groupBox_Waist.Name = "groupBox_Waist";
            this.groupBox_Waist.Size = new System.Drawing.Size(353, 196);
            this.groupBox_Waist.TabIndex = 10;
            this.groupBox_Waist.TabStop = false;
            this.groupBox_Waist.Text = "Waist";
            // 
            // listBox_belt
            // 
            this.listBox_belt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_belt.FormattingEnabled = true;
            this.listBox_belt.HorizontalScrollbar = true;
            this.listBox_belt.ItemHeight = 16;
            this.listBox_belt.Location = new System.Drawing.Point(10, 84);
            this.listBox_belt.Name = "listBox_belt";
            this.listBox_belt.Size = new System.Drawing.Size(336, 84);
            this.listBox_belt.TabIndex = 1;
            this.listBox_belt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_belt_MouseDoubleClick);
            this.listBox_belt.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_belt.MouseHover += new System.EventHandler(this.listBox_belt_OnMouseOver);
            // 
            // listBox_waist
            // 
            this.listBox_waist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_waist.FormattingEnabled = true;
            this.listBox_waist.HorizontalScrollbar = true;
            this.listBox_waist.ItemHeight = 16;
            this.listBox_waist.Location = new System.Drawing.Point(10, 29);
            this.listBox_waist.Name = "listBox_waist";
            this.listBox_waist.Size = new System.Drawing.Size(336, 52);
            this.listBox_waist.TabIndex = 0;
            this.listBox_waist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_waist_MouseDoubleClick);
            this.listBox_waist.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_waist.MouseHover += new System.EventHandler(this.listBox_waist_OnMouseOver);
            // 
            // groupBox_Back
            // 
            this.groupBox_Back.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox_Back.AutoSize = true;
            this.groupBox_Back.Controls.Add(this.listBox_back);
            this.groupBox_Back.Controls.Add(this.listBox_shouldersOver);
            this.groupBox_Back.Controls.Add(this.listBox_shouldersOn);
            this.groupBox_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Back.Location = new System.Drawing.Point(16, 447);
            this.groupBox_Back.Name = "groupBox_Back";
            this.groupBox_Back.Size = new System.Drawing.Size(307, 204);
            this.groupBox_Back.TabIndex = 11;
            this.groupBox_Back.TabStop = false;
            this.groupBox_Back.Text = "Back";
            // 
            // listBox_back
            // 
            this.listBox_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_back.FormattingEnabled = true;
            this.listBox_back.HorizontalScrollbar = true;
            this.listBox_back.ItemHeight = 16;
            this.listBox_back.Location = new System.Drawing.Point(6, 140);
            this.listBox_back.Name = "listBox_back";
            this.listBox_back.Size = new System.Drawing.Size(295, 36);
            this.listBox_back.TabIndex = 14;
            this.listBox_back.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_back_MouseDoubleClick);
            this.listBox_back.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_back.MouseHover += new System.EventHandler(this.listBox_back_OnMouseOver);
            // 
            // listBox_shouldersOver
            // 
            this.listBox_shouldersOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_shouldersOver.FormattingEnabled = true;
            this.listBox_shouldersOver.HorizontalScrollbar = true;
            this.listBox_shouldersOver.ItemHeight = 16;
            this.listBox_shouldersOver.Location = new System.Drawing.Point(6, 82);
            this.listBox_shouldersOver.Name = "listBox_shouldersOver";
            this.listBox_shouldersOver.Size = new System.Drawing.Size(295, 52);
            this.listBox_shouldersOver.TabIndex = 14;
            this.listBox_shouldersOver.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_shouldersOver_MouseDoubleClick);
            this.listBox_shouldersOver.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_shouldersOver.MouseHover += new System.EventHandler(this.listBox_shouldersOver_OnMouseOver);
            // 
            // listBox_shouldersOn
            // 
            this.listBox_shouldersOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_shouldersOn.FormattingEnabled = true;
            this.listBox_shouldersOn.HorizontalScrollbar = true;
            this.listBox_shouldersOn.ItemHeight = 16;
            this.listBox_shouldersOn.Location = new System.Drawing.Point(6, 29);
            this.listBox_shouldersOn.Name = "listBox_shouldersOn";
            this.listBox_shouldersOn.Size = new System.Drawing.Size(295, 52);
            this.listBox_shouldersOn.TabIndex = 14;
            this.listBox_shouldersOn.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_shouldersOn_MouseDoubleClick);
            this.listBox_shouldersOn.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_shouldersOn.MouseHover += new System.EventHandler(this.listBox_shouldersOn_OnMouseOver);
            // 
            // groupBox_Ground
            // 
            this.groupBox_Ground.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox_Ground.Controls.Add(this.listBox_atFeet);
            this.groupBox_Ground.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Ground.Location = new System.Drawing.Point(381, 697);
            this.groupBox_Ground.Name = "groupBox_Ground";
            this.groupBox_Ground.Size = new System.Drawing.Size(308, 98);
            this.groupBox_Ground.TabIndex = 12;
            this.groupBox_Ground.TabStop = false;
            this.groupBox_Ground.Text = "At Feet";
            // 
            // listBox_atFeet
            // 
            this.listBox_atFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_atFeet.FormattingEnabled = true;
            this.listBox_atFeet.HorizontalScrollbar = true;
            this.listBox_atFeet.ItemHeight = 16;
            this.listBox_atFeet.Location = new System.Drawing.Point(8, 36);
            this.listBox_atFeet.Name = "listBox_atFeet";
            this.listBox_atFeet.Size = new System.Drawing.Size(295, 36);
            this.listBox_atFeet.TabIndex = 0;
            this.listBox_atFeet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_atFeet_MouseDoubleClick);
            this.listBox_atFeet.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_atFeet.MouseHover += new System.EventHandler(this.listBox_atFeet_OnMouseOver);
            // 
            // comboBox_CharacterSelect
            // 
            this.comboBox_CharacterSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_CharacterSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_CharacterSelect.FormattingEnabled = true;
            this.comboBox_CharacterSelect.Location = new System.Drawing.Point(388, 12);
            this.comboBox_CharacterSelect.Name = "comboBox_CharacterSelect";
            this.comboBox_CharacterSelect.Size = new System.Drawing.Size(278, 32);
            this.comboBox_CharacterSelect.TabIndex = 13;
            this.comboBox_CharacterSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_CharacterSelect_SelectedIndexChanged);
            // 
            // button_scanInventory
            // 
            this.button_scanInventory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_scanInventory.Location = new System.Drawing.Point(363, 801);
            this.button_scanInventory.Name = "button_scanInventory";
            this.button_scanInventory.Size = new System.Drawing.Size(119, 27);
            this.button_scanInventory.TabIndex = 0;
            this.button_scanInventory.Text = "Scan Worn Items";
            this.button_scanInventory.UseVisualStyleBackColor = true;
            this.button_scanInventory.Click += new System.EventHandler(this.button_scanInventory_Click);
            // 
            // groupBox_hands
            // 
            this.groupBox_hands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_hands.AutoSize = true;
            this.groupBox_hands.Controls.Add(this.listBox_fingers);
            this.groupBox_hands.Controls.Add(this.listBox_wrist);
            this.groupBox_hands.Controls.Add(this.listBox_handWeapon);
            this.groupBox_hands.Controls.Add(this.listBox_hands);
            this.groupBox_hands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_hands.Location = new System.Drawing.Point(16, 626);
            this.groupBox_hands.Name = "groupBox_hands";
            this.groupBox_hands.Size = new System.Drawing.Size(307, 222);
            this.groupBox_hands.TabIndex = 14;
            this.groupBox_hands.TabStop = false;
            this.groupBox_hands.Text = "Hands";
            // 
            // listBox_fingers
            // 
            this.listBox_fingers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_fingers.FormattingEnabled = true;
            this.listBox_fingers.HorizontalScrollbar = true;
            this.listBox_fingers.ItemHeight = 16;
            this.listBox_fingers.Location = new System.Drawing.Point(6, 142);
            this.listBox_fingers.Name = "listBox_fingers";
            this.listBox_fingers.Size = new System.Drawing.Size(295, 52);
            this.listBox_fingers.TabIndex = 16;
            this.listBox_fingers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_fingers_MouseDoubleClick);
            this.listBox_fingers.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_fingers.MouseHover += new System.EventHandler(this.listBox_fingers_OnMouseOver);
            // 
            // listBox_wrist
            // 
            this.listBox_wrist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_wrist.FormattingEnabled = true;
            this.listBox_wrist.HorizontalScrollbar = true;
            this.listBox_wrist.ItemHeight = 16;
            this.listBox_wrist.Location = new System.Drawing.Point(6, 104);
            this.listBox_wrist.Name = "listBox_wrist";
            this.listBox_wrist.Size = new System.Drawing.Size(295, 36);
            this.listBox_wrist.TabIndex = 15;
            this.listBox_wrist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_wrist_MouseDoubleClick);
            this.listBox_wrist.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_wrist.MouseHover += new System.EventHandler(this.listBox_wrist_OnMouseOver);
            // 
            // listBox_handWeapon
            // 
            this.listBox_handWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_handWeapon.FormattingEnabled = true;
            this.listBox_handWeapon.HorizontalScrollbar = true;
            this.listBox_handWeapon.ItemHeight = 16;
            this.listBox_handWeapon.Location = new System.Drawing.Point(6, 66);
            this.listBox_handWeapon.Name = "listBox_handWeapon";
            this.listBox_handWeapon.Size = new System.Drawing.Size(295, 36);
            this.listBox_handWeapon.TabIndex = 0;
            this.listBox_handWeapon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_handWeapon_MouseDoubleClick);
            this.listBox_handWeapon.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_handWeapon.MouseHover += new System.EventHandler(this.listBox_handWeapon_OnMouseOver);
            // 
            // listBox_hands
            // 
            this.listBox_hands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_hands.FormattingEnabled = true;
            this.listBox_hands.HorizontalScrollbar = true;
            this.listBox_hands.ItemHeight = 16;
            this.listBox_hands.Location = new System.Drawing.Point(6, 28);
            this.listBox_hands.Name = "listBox_hands";
            this.listBox_hands.Size = new System.Drawing.Size(295, 36);
            this.listBox_hands.TabIndex = 15;
            this.listBox_hands.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_hands_MouseDoubleClick);
            this.listBox_hands.MouseLeave += new System.EventHandler(this.listBox_OnMouseLeave);
            this.listBox_hands.MouseHover += new System.EventHandler(this.listBox_hands_OnMouseOver);
            // 
            // pictureBox_male
            // 
            this.pictureBox_male.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_male.Image = global::Character_Inventory.Properties.Resources.character_male_small;
            this.pictureBox_male.InitialImage = global::Character_Inventory.Properties.Resources.character_male_small;
            this.pictureBox_male.Location = new System.Drawing.Point(592, 57);
            this.pictureBox_male.Name = "pictureBox_male";
            this.pictureBox_male.Size = new System.Drawing.Size(74, 197);
            this.pictureBox_male.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_male.TabIndex = 16;
            this.pictureBox_male.TabStop = false;
            // 
            // label_Slots_Head
            // 
            this.label_Slots_Head.AutoSize = true;
            this.label_Slots_Head.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_Head.Location = new System.Drawing.Point(325, 57);
            this.label_Slots_Head.Name = "label_Slots_Head";
            this.label_Slots_Head.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_Head.TabIndex = 17;
            this.label_Slots_Head.Text = "0";
            // 
            // label_Slots_headArmor
            // 
            this.label_Slots_headArmor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_headArmor.AutoSize = true;
            this.label_Slots_headArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_headArmor.Location = new System.Drawing.Point(325, 94);
            this.label_Slots_headArmor.Name = "label_Slots_headArmor";
            this.label_Slots_headArmor.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_headArmor.TabIndex = 18;
            this.label_Slots_headArmor.Text = "0";
            // 
            // label_Slots_hairTied
            // 
            this.label_Slots_hairTied.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_hairTied.AutoSize = true;
            this.label_Slots_hairTied.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_hairTied.Location = new System.Drawing.Point(325, 129);
            this.label_Slots_hairTied.Name = "label_Slots_hairTied";
            this.label_Slots_hairTied.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_hairTied.TabIndex = 19;
            this.label_Slots_hairTied.Text = "0";
            // 
            // label_Slots_hairPlaced
            // 
            this.label_Slots_hairPlaced.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_hairPlaced.AutoSize = true;
            this.label_Slots_hairPlaced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_hairPlaced.Location = new System.Drawing.Point(325, 166);
            this.label_Slots_hairPlaced.Name = "label_Slots_hairPlaced";
            this.label_Slots_hairPlaced.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_hairPlaced.TabIndex = 20;
            this.label_Slots_hairPlaced.Text = "0";
            // 
            // label_Slots_leftEye
            // 
            this.label_Slots_leftEye.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_leftEye.AutoSize = true;
            this.label_Slots_leftEye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_leftEye.Location = new System.Drawing.Point(325, 205);
            this.label_Slots_leftEye.Name = "label_Slots_leftEye";
            this.label_Slots_leftEye.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_leftEye.TabIndex = 21;
            this.label_Slots_leftEye.Text = "0";
            // 
            // label_Slots_rightEye
            // 
            this.label_Slots_rightEye.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_rightEye.AutoSize = true;
            this.label_Slots_rightEye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_rightEye.Location = new System.Drawing.Point(325, 241);
            this.label_Slots_rightEye.Name = "label_Slots_rightEye";
            this.label_Slots_rightEye.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_rightEye.TabIndex = 22;
            this.label_Slots_rightEye.Text = "0";
            // 
            // label_Slots_ear
            // 
            this.label_Slots_ear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_ear.AutoSize = true;
            this.label_Slots_ear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_ear.Location = new System.Drawing.Point(325, 277);
            this.label_Slots_ear.Name = "label_Slots_ear";
            this.label_Slots_ear.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_ear.TabIndex = 23;
            this.label_Slots_ear.Text = "0";
            // 
            // label_Slots_bothEars
            // 
            this.label_Slots_bothEars.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_bothEars.AutoSize = true;
            this.label_Slots_bothEars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_bothEars.Location = new System.Drawing.Point(325, 311);
            this.label_Slots_bothEars.Name = "label_Slots_bothEars";
            this.label_Slots_bothEars.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_bothEars.TabIndex = 24;
            this.label_Slots_bothEars.Text = "0";
            // 
            // label_Slots_nose
            // 
            this.label_Slots_nose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_nose.AutoSize = true;
            this.label_Slots_nose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_nose.Location = new System.Drawing.Point(325, 349);
            this.label_Slots_nose.Name = "label_Slots_nose";
            this.label_Slots_nose.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_nose.TabIndex = 25;
            this.label_Slots_nose.Text = "0";
            // 
            // label_Slots_neck
            // 
            this.label_Slots_neck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_neck.AutoSize = true;
            this.label_Slots_neck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_neck.Location = new System.Drawing.Point(325, 385);
            this.label_Slots_neck.Name = "label_Slots_neck";
            this.label_Slots_neck.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_neck.TabIndex = 26;
            this.label_Slots_neck.Text = "0";
            // 
            // label_Slots_shouldersOn
            // 
            this.label_Slots_shouldersOn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_shouldersOn.AutoSize = true;
            this.label_Slots_shouldersOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_shouldersOn.Location = new System.Drawing.Point(325, 498);
            this.label_Slots_shouldersOn.Name = "label_Slots_shouldersOn";
            this.label_Slots_shouldersOn.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_shouldersOn.TabIndex = 27;
            this.label_Slots_shouldersOn.Text = "0";
            // 
            // label_Slots_shouldersOver
            // 
            this.label_Slots_shouldersOver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_shouldersOver.AutoSize = true;
            this.label_Slots_shouldersOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_shouldersOver.Location = new System.Drawing.Point(325, 535);
            this.label_Slots_shouldersOver.Name = "label_Slots_shouldersOver";
            this.label_Slots_shouldersOver.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_shouldersOver.TabIndex = 28;
            this.label_Slots_shouldersOver.Text = "0";
            // 
            // label_Slots_back
            // 
            this.label_Slots_back.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_back.AutoSize = true;
            this.label_Slots_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_back.Location = new System.Drawing.Point(325, 572);
            this.label_Slots_back.Name = "label_Slots_back";
            this.label_Slots_back.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_back.TabIndex = 29;
            this.label_Slots_back.Text = "0";
            // 
            // label_Slots_hands
            // 
            this.label_Slots_hands.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_hands.AutoSize = true;
            this.label_Slots_hands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_hands.Location = new System.Drawing.Point(325, 658);
            this.label_Slots_hands.Name = "label_Slots_hands";
            this.label_Slots_hands.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_hands.TabIndex = 30;
            this.label_Slots_hands.Text = "0";
            // 
            // label_Slots_handWeapon
            // 
            this.label_Slots_handWeapon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_handWeapon.AutoSize = true;
            this.label_Slots_handWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_handWeapon.Location = new System.Drawing.Point(325, 698);
            this.label_Slots_handWeapon.Name = "label_Slots_handWeapon";
            this.label_Slots_handWeapon.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_handWeapon.TabIndex = 31;
            this.label_Slots_handWeapon.Text = "0";
            // 
            // label_Slots_wrist
            // 
            this.label_Slots_wrist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Slots_wrist.AutoSize = true;
            this.label_Slots_wrist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_wrist.Location = new System.Drawing.Point(325, 737);
            this.label_Slots_wrist.Name = "label_Slots_wrist";
            this.label_Slots_wrist.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_wrist.TabIndex = 32;
            this.label_Slots_wrist.Text = "0";
            // 
            // label_Slots_fingers
            // 
            this.label_Slots_fingers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Slots_fingers.AutoSize = true;
            this.label_Slots_fingers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_fingers.Location = new System.Drawing.Point(325, 783);
            this.label_Slots_fingers.Name = "label_Slots_fingers";
            this.label_Slots_fingers.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_fingers.TabIndex = 33;
            this.label_Slots_fingers.Text = "0";
            // 
            // label_Slots_pants
            // 
            this.label_Slots_pants.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Slots_pants.AutoSize = true;
            this.label_Slots_pants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_pants.Location = new System.Drawing.Point(696, 337);
            this.label_Slots_pants.Name = "label_Slots_pants";
            this.label_Slots_pants.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_pants.TabIndex = 34;
            this.label_Slots_pants.Text = "0";
            // 
            // label_Slots_legArmor
            // 
            this.label_Slots_legArmor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Slots_legArmor.AutoSize = true;
            this.label_Slots_legArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_legArmor.Location = new System.Drawing.Point(696, 374);
            this.label_Slots_legArmor.Name = "label_Slots_legArmor";
            this.label_Slots_legArmor.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_legArmor.TabIndex = 35;
            this.label_Slots_legArmor.Text = "0";
            // 
            // label_Slots_thigh
            // 
            this.label_Slots_thigh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Slots_thigh.AutoSize = true;
            this.label_Slots_thigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_thigh.Location = new System.Drawing.Point(696, 423);
            this.label_Slots_thigh.Name = "label_Slots_thigh";
            this.label_Slots_thigh.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_thigh.TabIndex = 36;
            this.label_Slots_thigh.Text = "0";
            // 
            // label_Slots_kneeWeapon
            // 
            this.label_Slots_kneeWeapon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Slots_kneeWeapon.AutoSize = true;
            this.label_Slots_kneeWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_kneeWeapon.Location = new System.Drawing.Point(696, 483);
            this.label_Slots_kneeWeapon.Name = "label_Slots_kneeWeapon";
            this.label_Slots_kneeWeapon.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_kneeWeapon.TabIndex = 37;
            this.label_Slots_kneeWeapon.Text = "0";
            // 
            // label_Slots_ankle
            // 
            this.label_Slots_ankle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Slots_ankle.AutoSize = true;
            this.label_Slots_ankle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_ankle.Location = new System.Drawing.Point(696, 532);
            this.label_Slots_ankle.Name = "label_Slots_ankle";
            this.label_Slots_ankle.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_ankle.TabIndex = 38;
            this.label_Slots_ankle.Text = "0";
            // 
            // label_Slots_footWeapon
            // 
            this.label_Slots_footWeapon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Slots_footWeapon.AutoSize = true;
            this.label_Slots_footWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_footWeapon.Location = new System.Drawing.Point(696, 590);
            this.label_Slots_footWeapon.Name = "label_Slots_footWeapon";
            this.label_Slots_footWeapon.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_footWeapon.TabIndex = 39;
            this.label_Slots_footWeapon.Text = "0";
            // 
            // label_Slots_feet
            // 
            this.label_Slots_feet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Slots_feet.AutoSize = true;
            this.label_Slots_feet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_feet.Location = new System.Drawing.Point(696, 628);
            this.label_Slots_feet.Name = "label_Slots_feet";
            this.label_Slots_feet.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_feet.TabIndex = 40;
            this.label_Slots_feet.Text = "0";
            // 
            // label_Slots_armUpper
            // 
            this.label_Slots_armUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Slots_armUpper.AutoSize = true;
            this.label_Slots_armUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_armUpper.Location = new System.Drawing.Point(1095, 57);
            this.label_Slots_armUpper.Name = "label_Slots_armUpper";
            this.label_Slots_armUpper.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_armUpper.TabIndex = 41;
            this.label_Slots_armUpper.Text = "0";
            // 
            // label_Slots_armArmor
            // 
            this.label_Slots_armArmor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_armArmor.AutoSize = true;
            this.label_Slots_armArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_armArmor.Location = new System.Drawing.Point(1095, 111);
            this.label_Slots_armArmor.Name = "label_Slots_armArmor";
            this.label_Slots_armArmor.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_armArmor.TabIndex = 42;
            this.label_Slots_armArmor.Text = "0";
            // 
            // label_Slots_elbowWeapon
            // 
            this.label_Slots_elbowWeapon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_elbowWeapon.AutoSize = true;
            this.label_Slots_elbowWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_elbowWeapon.Location = new System.Drawing.Point(1095, 151);
            this.label_Slots_elbowWeapon.Name = "label_Slots_elbowWeapon";
            this.label_Slots_elbowWeapon.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_elbowWeapon.TabIndex = 43;
            this.label_Slots_elbowWeapon.Text = "0";
            // 
            // label_Slots_shieldWorn
            // 
            this.label_Slots_shieldWorn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_shieldWorn.AutoSize = true;
            this.label_Slots_shieldWorn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_shieldWorn.Location = new System.Drawing.Point(1095, 188);
            this.label_Slots_shieldWorn.Name = "label_Slots_shieldWorn";
            this.label_Slots_shieldWorn.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_shieldWorn.TabIndex = 44;
            this.label_Slots_shieldWorn.Text = "0";
            // 
            // label_Slots_parryStick
            // 
            this.label_Slots_parryStick.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_parryStick.AutoSize = true;
            this.label_Slots_parryStick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_parryStick.Location = new System.Drawing.Point(1095, 225);
            this.label_Slots_parryStick.Name = "label_Slots_parryStick";
            this.label_Slots_parryStick.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_parryStick.TabIndex = 45;
            this.label_Slots_parryStick.Text = "0";
            // 
            // label_Slots_body
            // 
            this.label_Slots_body.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_body.AutoSize = true;
            this.label_Slots_body.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_body.Location = new System.Drawing.Point(1095, 340);
            this.label_Slots_body.Name = "label_Slots_body";
            this.label_Slots_body.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_body.TabIndex = 46;
            this.label_Slots_body.Text = "0";
            // 
            // label_Slots_shirtArmor
            // 
            this.label_Slots_shirtArmor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_shirtArmor.AutoSize = true;
            this.label_Slots_shirtArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_shirtArmor.Location = new System.Drawing.Point(1095, 465);
            this.label_Slots_shirtArmor.Name = "label_Slots_shirtArmor";
            this.label_Slots_shirtArmor.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_shirtArmor.TabIndex = 47;
            this.label_Slots_shirtArmor.Text = "0";
            // 
            // label_Slots_shirt
            // 
            this.label_Slots_shirt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_shirt.AutoSize = true;
            this.label_Slots_shirt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_shirt.Location = new System.Drawing.Point(1095, 519);
            this.label_Slots_shirt.Name = "label_Slots_shirt";
            this.label_Slots_shirt.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_shirt.TabIndex = 48;
            this.label_Slots_shirt.Text = "0";
            // 
            // label_Slots_waist
            // 
            this.label_Slots_waist.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_waist.AutoSize = true;
            this.label_Slots_waist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_waist.Location = new System.Drawing.Point(1095, 670);
            this.label_Slots_waist.Name = "label_Slots_waist";
            this.label_Slots_waist.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_waist.TabIndex = 49;
            this.label_Slots_waist.Text = "0";
            // 
            // label_Slots_belt
            // 
            this.label_Slots_belt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Slots_belt.AutoSize = true;
            this.label_Slots_belt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_belt.Location = new System.Drawing.Point(1095, 731);
            this.label_Slots_belt.Name = "label_Slots_belt";
            this.label_Slots_belt.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_belt.TabIndex = 50;
            this.label_Slots_belt.Text = "0";
            // 
            // label_Slots_ground
            // 
            this.label_Slots_ground.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_Slots_ground.AutoSize = true;
            this.label_Slots_ground.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_ground.Location = new System.Drawing.Point(696, 743);
            this.label_Slots_ground.Name = "label_Slots_ground";
            this.label_Slots_ground.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_ground.TabIndex = 51;
            this.label_Slots_ground.Text = "0";
            // 
            // label_Slots_tail
            // 
            this.label_Slots_tail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Slots_tail.AutoSize = true;
            this.label_Slots_tail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slots_tail.Location = new System.Drawing.Point(1095, 562);
            this.label_Slots_tail.Name = "label_Slots_tail";
            this.label_Slots_tail.Size = new System.Drawing.Size(16, 16);
            this.label_Slots_tail.TabIndex = 52;
            this.label_Slots_tail.Text = "0";
            // 
            // label_youAreWearing
            // 
            this.label_youAreWearing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_youAreWearing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_youAreWearing.Location = new System.Drawing.Point(375, 50);
            this.label_youAreWearing.Name = "label_youAreWearing";
            this.label_youAreWearing.Size = new System.Drawing.Size(211, 46);
            this.label_youAreWearing.TabIndex = 53;
            this.label_youAreWearing.Text = "Total Items You Are Wearing:";
            this.label_youAreWearing.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label_totalWorn
            // 
            this.label_totalWorn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_totalWorn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalWorn.Location = new System.Drawing.Point(449, 103);
            this.label_totalWorn.Name = "label_totalWorn";
            this.label_totalWorn.Size = new System.Drawing.Size(33, 17);
            this.label_totalWorn.TabIndex = 54;
            this.label_totalWorn.Text = "0";
            // 
            // label_itemLocation
            // 
            this.label_itemLocation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_itemLocation.AutoSize = true;
            this.label_itemLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_itemLocation.Location = new System.Drawing.Point(390, 262);
            this.label_itemLocation.Name = "label_itemLocation";
            this.label_itemLocation.Size = new System.Drawing.Size(108, 16);
            this.label_itemLocation.TabIndex = 55;
            this.label_itemLocation.Text = "Item Location: ";
            // 
            // label_locationText
            // 
            this.label_locationText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_locationText.AutoSize = true;
            this.label_locationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_locationText.Location = new System.Drawing.Point(498, 262);
            this.label_locationText.Name = "label_locationText";
            this.label_locationText.Size = new System.Drawing.Size(11, 16);
            this.label_locationText.TabIndex = 56;
            this.label_locationText.Text = " ";
            // 
            // button_scanContainer
            // 
            this.button_scanContainer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_scanContainer.Location = new System.Drawing.Point(488, 801);
            this.button_scanContainer.Name = "button_scanContainer";
            this.button_scanContainer.Size = new System.Drawing.Size(110, 27);
            this.button_scanContainer.TabIndex = 1;
            this.button_scanContainer.Text = "Scan Containers";
            this.button_scanContainer.UseVisualStyleBackColor = true;
            this.button_scanContainer.Click += new System.EventHandler(this.button_scanContainer_Click);
            // 
            // checkBox_showContainers
            // 
            this.checkBox_showContainers.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox_showContainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_showContainers.Location = new System.Drawing.Point(378, 131);
            this.checkBox_showContainers.Name = "checkBox_showContainers";
            this.checkBox_showContainers.Size = new System.Drawing.Size(178, 36);
            this.checkBox_showContainers.TabIndex = 57;
            this.checkBox_showContainers.Text = "Show Containers Only";
            this.checkBox_showContainers.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox_showContainers.UseVisualStyleBackColor = true;
            this.checkBox_showContainers.CheckedChanged += new System.EventHandler(this.checkBox_showContainers_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 840);
            this.Controls.Add(this.checkBox_showContainers);
            this.Controls.Add(this.button_scanContainer);
            this.Controls.Add(this.label_locationText);
            this.Controls.Add(this.label_itemLocation);
            this.Controls.Add(this.label_totalWorn);
            this.Controls.Add(this.label_youAreWearing);
            this.Controls.Add(this.label_Slots_tail);
            this.Controls.Add(this.label_Slots_ground);
            this.Controls.Add(this.label_Slots_belt);
            this.Controls.Add(this.label_Slots_waist);
            this.Controls.Add(this.label_Slots_shirt);
            this.Controls.Add(this.label_Slots_shirtArmor);
            this.Controls.Add(this.label_Slots_body);
            this.Controls.Add(this.label_Slots_parryStick);
            this.Controls.Add(this.label_Slots_shieldWorn);
            this.Controls.Add(this.label_Slots_elbowWeapon);
            this.Controls.Add(this.label_Slots_armArmor);
            this.Controls.Add(this.label_Slots_armUpper);
            this.Controls.Add(this.label_Slots_feet);
            this.Controls.Add(this.label_Slots_footWeapon);
            this.Controls.Add(this.label_Slots_ankle);
            this.Controls.Add(this.label_Slots_kneeWeapon);
            this.Controls.Add(this.label_Slots_thigh);
            this.Controls.Add(this.label_Slots_legArmor);
            this.Controls.Add(this.label_Slots_pants);
            this.Controls.Add(this.label_Slots_fingers);
            this.Controls.Add(this.label_Slots_wrist);
            this.Controls.Add(this.label_Slots_handWeapon);
            this.Controls.Add(this.label_Slots_hands);
            this.Controls.Add(this.label_Slots_back);
            this.Controls.Add(this.label_Slots_shouldersOver);
            this.Controls.Add(this.label_Slots_shouldersOn);
            this.Controls.Add(this.label_Slots_neck);
            this.Controls.Add(this.label_Slots_nose);
            this.Controls.Add(this.label_Slots_bothEars);
            this.Controls.Add(this.label_Slots_ear);
            this.Controls.Add(this.label_Slots_rightEye);
            this.Controls.Add(this.label_Slots_leftEye);
            this.Controls.Add(this.label_Slots_hairPlaced);
            this.Controls.Add(this.label_Slots_hairTied);
            this.Controls.Add(this.label_Slots_headArmor);
            this.Controls.Add(this.label_Slots_Head);
            this.Controls.Add(this.pictureBox_male);
            this.Controls.Add(this.groupBox_hands);
            this.Controls.Add(this.button_scanInventory);
            this.Controls.Add(this.comboBox_CharacterSelect);
            this.Controls.Add(this.groupBox_Back);
            this.Controls.Add(this.groupBox_Ground);
            this.Controls.Add(this.groupBox_Waist);
            this.Controls.Add(this.groupBox_Body);
            this.Controls.Add(this.groupBox_Legs);
            this.Controls.Add(this.groupBox_Arms);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.button_closewindow);
            this.Controls.Add(this.groupBox_Head);
            this.Name = "MainForm";
            this.Text = "Character_Inventory";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_Load);
            this.groupBox_Head.ResumeLayout(false);
            this.groupBox_Arms.ResumeLayout(false);
            this.groupBox_Legs.ResumeLayout(false);
            this.groupBox_Body.ResumeLayout(false);
            this.groupBox_Waist.ResumeLayout(false);
            this.groupBox_Back.ResumeLayout(false);
            this.groupBox_Ground.ResumeLayout(false);
            this.groupBox_hands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_male)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_closewindow;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.ListBox listBox_body;
        private System.Windows.Forms.ListBox listBox_head;
        private System.Windows.Forms.GroupBox groupBox_Head;
        private System.Windows.Forms.GroupBox groupBox_Arms;
        private System.Windows.Forms.GroupBox groupBox_Legs;
        private System.Windows.Forms.GroupBox groupBox_Body;
        private System.Windows.Forms.GroupBox groupBox_Waist;
        private System.Windows.Forms.GroupBox groupBox_Back;
        private System.Windows.Forms.GroupBox groupBox_Ground;
        private System.Windows.Forms.ComboBox comboBox_CharacterSelect;
        private System.Windows.Forms.Button button_scanInventory;
        private System.Windows.Forms.ListBox listBox_headArmor;
        private System.Windows.Forms.ListBox listBox_nose;
        private System.Windows.Forms.ListBox listBox_bothEars;
        private System.Windows.Forms.ListBox listBox_ear;
        private System.Windows.Forms.ListBox listBox_righteye;
        private System.Windows.Forms.ListBox listBox_leftEye;
        private System.Windows.Forms.ListBox listBox_hairPlaced;
        private System.Windows.Forms.ListBox listBox_hairTied;
        private System.Windows.Forms.ListBox listBox_neck;
        private System.Windows.Forms.ListBox listBox_back;
        private System.Windows.Forms.ListBox listBox_shouldersOver;
        private System.Windows.Forms.ListBox listBox_shouldersOn;
        private System.Windows.Forms.ListBox listBox_shirt;
        private System.Windows.Forms.ListBox listBox_shirtArmor;
        private System.Windows.Forms.ListBox listBox_belt;
        private System.Windows.Forms.ListBox listBox_waist;
        private System.Windows.Forms.ListBox listBox_armArmor;
        private System.Windows.Forms.ListBox listBox_armUpper;
        private System.Windows.Forms.GroupBox groupBox_hands;
        private System.Windows.Forms.ListBox listBox_elbowWeapon;
        private System.Windows.Forms.ListBox listBox_hands;
        private System.Windows.Forms.ListBox listBox_shieldWorn;
        private System.Windows.Forms.ListBox listBox_parryStick;
        private System.Windows.Forms.ListBox listBox_handWeapon;
        private System.Windows.Forms.ListBox listBox_fingers;
        private System.Windows.Forms.ListBox listBox_wrist;
        private System.Windows.Forms.ListBox listBox_atFeet;
        private System.Windows.Forms.ListBox listBox_legArmor;
        private System.Windows.Forms.ListBox listBox_pants;
        private System.Windows.Forms.ListBox listBox_thigh;
        private System.Windows.Forms.ListBox listBox_feet;
        private System.Windows.Forms.ListBox listBox_footWeapon;
        private System.Windows.Forms.ListBox listBox_ankle;
        private System.Windows.Forms.ListBox listBox_kneeWeapon;
        private System.Windows.Forms.PictureBox pictureBox_male;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_Slots_Head;
        private System.Windows.Forms.Label label_Slots_headArmor;
        private System.Windows.Forms.Label label_Slots_hairTied;
        private System.Windows.Forms.Label label_Slots_hairPlaced;
        private System.Windows.Forms.Label label_Slots_leftEye;
        private System.Windows.Forms.Label label_Slots_rightEye;
        private System.Windows.Forms.Label label_Slots_ear;
        private System.Windows.Forms.Label label_Slots_bothEars;
        private System.Windows.Forms.Label label_Slots_nose;
        private System.Windows.Forms.Label label_Slots_neck;
        private System.Windows.Forms.Label label_Slots_shouldersOn;
        private System.Windows.Forms.Label label_Slots_shouldersOver;
        private System.Windows.Forms.Label label_Slots_back;
        private System.Windows.Forms.Label label_Slots_hands;
        private System.Windows.Forms.Label label_Slots_handWeapon;
        private System.Windows.Forms.Label label_Slots_wrist;
        private System.Windows.Forms.Label label_Slots_fingers;
        private System.Windows.Forms.Label label_Slots_pants;
        private System.Windows.Forms.Label label_Slots_legArmor;
        private System.Windows.Forms.Label label_Slots_thigh;
        private System.Windows.Forms.Label label_Slots_kneeWeapon;
        private System.Windows.Forms.Label label_Slots_ankle;
        private System.Windows.Forms.Label label_Slots_footWeapon;
        private System.Windows.Forms.Label label_Slots_feet;
        private System.Windows.Forms.Label label_Slots_armUpper;
        private System.Windows.Forms.Label label_Slots_armArmor;
        private System.Windows.Forms.Label label_Slots_elbowWeapon;
        private System.Windows.Forms.Label label_Slots_shieldWorn;
        private System.Windows.Forms.Label label_Slots_parryStick;
        private System.Windows.Forms.Label label_Slots_body;
        private System.Windows.Forms.Label label_Slots_shirtArmor;
        private System.Windows.Forms.Label label_Slots_shirt;
        private System.Windows.Forms.Label label_Slots_waist;
        private System.Windows.Forms.Label label_Slots_belt;
        private System.Windows.Forms.Label label_Slots_ground;
        private System.Windows.Forms.ListBox listBox_tail;
        private System.Windows.Forms.Label label_Slots_tail;
        private System.Windows.Forms.Label label_youAreWearing;
        private System.Windows.Forms.Label label_totalWorn;
        private System.Windows.Forms.Label label_itemLocation;
        private System.Windows.Forms.Label label_locationText;
        private System.Windows.Forms.Button button_scanContainer;
        private System.Windows.Forms.CheckBox checkBox_showContainers;
    }

}



