﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      此代码由编码的 UI 测试生成器生成。
//      版本: 12.0.0.0
//
//      如果重新生成代码，则更改此文件可能会导致错误的行为，
//      并将丢失这些更改。
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace CodedUITestProject1
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("编码的 UI 测试生成器", "12.0.21005.1")]
    public partial class UIMap
    {
        
        /// <summary>
        /// RecordedMethod1 - 使用“RecordedMethod1Params”将参数传递到此方法中。
        /// </summary>
        public void RecordedMethod1()
        {
            #region Variable Declarations
            WinWindow uI登录GoogleChromeWindow1 = this.UI登录GoogleChromeWindow.UI登录GoogleChromeWindow1;
            WinControl uIChromeLegacyWindowDocument = this.UI登录GoogleChromeWindow.UIChromeLegacyWindowWindow.UIChromeLegacyWindowDocument;
            #endregion

            // 单击 “登录 - Google Chrome” 窗口
            Mouse.Click(uI登录GoogleChromeWindow1, new Point(105, 459));

            // 单击 “登录 - Google Chrome” 窗口
            Mouse.Click(uI登录GoogleChromeWindow1, new Point(195, 471));

            // 在 “Chrome Legacy Window” 文档 中键入“{NumPad1}{NumPad5}{NumPad1}{NumPad5}{NumPad8}{NumPad1}{NumPad5}{NumPad5}{NumPad5}{NumPad1}{NumPad1}”
            Keyboard.SendKeys(uIChromeLegacyWindowDocument, this.RecordedMethod1Params.UIChromeLegacyWindowDocumentSendKeys, ModifierKeys.None);

            // 单击 “登录 - Google Chrome” 窗口
            Mouse.Click(uI登录GoogleChromeWindow1, new Point(305, 519));

            // 单击 “登录 - Google Chrome” 窗口
            Mouse.Click(uI登录GoogleChromeWindow1, new Point(159, 519));

            // 在 “Chrome Legacy Window” 文档 中键入“{NumPad1}{NumPad2}{NumPad3}{NumPad4}{NumPad5}{NumPad6}”
            Keyboard.SendKeys(uIChromeLegacyWindowDocument, this.RecordedMethod1Params.UIChromeLegacyWindowDocumentSendKeys1, ModifierKeys.None);

            // 单击 “登录 - Google Chrome” 窗口
            Mouse.Click(uI登录GoogleChromeWindow1, new Point(199, 610));
        }
        
        #region Properties
        public virtual RecordedMethod1Params RecordedMethod1Params
        {
            get
            {
                if ((this.mRecordedMethod1Params == null))
                {
                    this.mRecordedMethod1Params = new RecordedMethod1Params();
                }
                return this.mRecordedMethod1Params;
            }
        }
        
        public UI登录GoogleChromeWindow UI登录GoogleChromeWindow
        {
            get
            {
                if ((this.mUI登录GoogleChromeWindow == null))
                {
                    this.mUI登录GoogleChromeWindow = new UI登录GoogleChromeWindow();
                }
                return this.mUI登录GoogleChromeWindow;
            }
        }
        #endregion
        
        #region Fields
        private RecordedMethod1Params mRecordedMethod1Params;
        
        private UI登录GoogleChromeWindow mUI登录GoogleChromeWindow;
        #endregion
    }
    
    /// <summary>
    /// 要传递到“RecordedMethod1”中的参数
    /// </summary>
    [GeneratedCode("编码的 UI 测试生成器", "12.0.21005.1")]
    public class RecordedMethod1Params
    {
        
        #region Fields
        /// <summary>
        /// 在 “Chrome Legacy Window” 文档 中键入“{NumPad1}{NumPad5}{NumPad1}{NumPad5}{NumPad8}{NumPad1}{NumPad5}{NumPad5}{NumPad5}{NumPad1}{NumPad1}”
        /// </summary>
        public string UIChromeLegacyWindowDocumentSendKeys = "{NumPad1}{NumPad5}{NumPad1}{NumPad5}{NumPad8}{NumPad1}{NumPad5}{NumPad5}{NumPad5}" +
            "{NumPad1}{NumPad1}";
        
        /// <summary>
        /// 在 “Chrome Legacy Window” 文档 中键入“{NumPad1}{NumPad2}{NumPad3}{NumPad4}{NumPad5}{NumPad6}”
        /// </summary>
        public string UIChromeLegacyWindowDocumentSendKeys1 = "{NumPad1}{NumPad2}{NumPad3}{NumPad4}{NumPad5}{NumPad6}";
        #endregion
    }
    
    [GeneratedCode("编码的 UI 测试生成器", "12.0.21005.1")]
    public class UI登录GoogleChromeWindow : WinWindow
    {
        
        public UI登录GoogleChromeWindow()
        {
            #region 搜索条件
            this.SearchProperties[WinWindow.PropertyNames.Name] = "登录 - Google Chrome";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "Chrome_WidgetWin_1";
            this.WindowTitles.Add("登录 - Google Chrome");
            #endregion
        }
        
        #region Properties
        public WinWindow UI登录GoogleChromeWindow1
        {
            get
            {
                if ((this.mUI登录GoogleChromeWindow1 == null))
                {
                    this.mUI登录GoogleChromeWindow1 = new WinWindow(this);
                    #region 搜索条件
                    this.mUI登录GoogleChromeWindow1.SearchProperties[WinWindow.PropertyNames.Name] = "登录 - Google Chrome（隐身）";
                    this.mUI登录GoogleChromeWindow1.WindowTitles.Add("登录 - Google Chrome");
                    #endregion
                }
                return this.mUI登录GoogleChromeWindow1;
            }
        }
        
        public UIChromeLegacyWindowWindow UIChromeLegacyWindowWindow
        {
            get
            {
                if ((this.mUIChromeLegacyWindowWindow == null))
                {
                    this.mUIChromeLegacyWindowWindow = new UIChromeLegacyWindowWindow(this);
                }
                return this.mUIChromeLegacyWindowWindow;
            }
        }
        #endregion
        
        #region Fields
        private WinWindow mUI登录GoogleChromeWindow1;
        
        private UIChromeLegacyWindowWindow mUIChromeLegacyWindowWindow;
        #endregion
    }
    
    [GeneratedCode("编码的 UI 测试生成器", "12.0.21005.1")]
    public class UIChromeLegacyWindowWindow : WinWindow
    {
        
        public UIChromeLegacyWindowWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region 搜索条件
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "548833040";
            this.WindowTitles.Add("登录 - Google Chrome");
            #endregion
        }
        
        #region Properties
        public WinControl UIChromeLegacyWindowDocument
        {
            get
            {
                if ((this.mUIChromeLegacyWindowDocument == null))
                {
                    this.mUIChromeLegacyWindowDocument = new WinControl(this);
                    #region 搜索条件
                    this.mUIChromeLegacyWindowDocument.SearchProperties[UITestControl.PropertyNames.ControlType] = "Document";
                    this.mUIChromeLegacyWindowDocument.WindowTitles.Add("登录 - Google Chrome");
                    #endregion
                }
                return this.mUIChromeLegacyWindowDocument;
            }
        }
        #endregion
        
        #region Fields
        private WinControl mUIChromeLegacyWindowDocument;
        #endregion
    }
}
