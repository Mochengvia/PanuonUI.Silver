<a href="https://996.icu" target='_blank'><img src="https://img.shields.io/badge/link-996.icu-red.svg"></a>
<a href="https://996.icu" target='_blank'><img src="https://camo.githubusercontent.com/8948ee9e753309fa3e978b3a0bdeda5a0c3f98ec/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f2e6e65742d253345253344342e302d626c75652e737667"></a>

# Panuon.UI.Silver
Panuon.UI optimized version. A beautiful wpf ui library using templates &amp; attached properties.  
Panuon.UI的优化版本。一个漂亮的、使用样式与附加属性的WPF UI控件库。

You can download Panuon.UI.Silver (pre-release) from nuget now. Check "include pre-release" option before query.  
Panuon.UI.Silver(预发行版)现已加入Nuget平台。在搜索"Panuon.UI.Silver"前，请在Nuget包管理器中勾选“包括预发行版”。  

Email : zeoun@qq.com  
QQ Group : 718778191  
Zhihu : @末城via

# News 动态  
#### 2019-10-25 v1.0.8.5
修复了Calendar和DateTimePicker在选择月份时，若已选中了该月不存在的天数将引发崩溃的问题。  
修复了Calendar和DateTimePicker无法处理SelectedDateTimeChanged事件的问题。  
新增了DateTimePicker的Header和HeaderWidth属性。  
修复了IconHelper.Width对TextBox不生效的问题。  

TabControl增强：  
新增ItemCornerRadius属性，用于设置选项卡子项的统一圆角大小。该属性也可直接对TabItem控件生效。  
新增ItemBackground属性，用于设置选项卡子项的统一背景色。  
新增HeaderPanelBackground属性，用于设置选项卡标题栏的背景色。   

Expander增强：  
移除了HeaderHeight属性，新增HeaderPadding（默认值5,5,0,5）、HeaderBackground、ShadowColor（默认值为Null）属性。  
调整默认Padding属性值为5,5,0,5。  

GroupBox增强：  
移除了Effect属性，新增Icon、HeaderPadding（默认值5,5,0,5）、HeaderBackground、ShadowColor（默认值为Null）属性。  
调整默认Padding属性值为5,5,0,5。  

#### 2019-10-21 v1.0.8.4
修复了ScrollViewer.CanContentScroll在多个控件中不生效的问题。  
移除了GroupBox默认内部间距为0,3,0,3的设置。  
[严重]修复了ListBox样式没有应用到项目的问题。   

# ReleaseNote 发布文档  

https://github.com/Panuon/Panuon.Documents/blob/master/Documents/PanuonUI.Silver/release-note.zh-cn.md

# Document 文档

Chinese document(English document is still being written, you can translate it by google or other translators):  
中文文档：  
https://github.com/Panuon/Panuon.Documents/blob/master/Documents/PanuonUI.Silver/zh-cn.md

# Case 案例  

### Morin 魔音

http://www.huanghunxiao.com/  
  
![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/case_morin_3.png)  

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/case_morin_2.png)  




# Examples 示例  

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/window_1.png)

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/window_2.png)

# Donate  捐赠
Panuon.UI.Silver is an open source library.Your support will motivate me to continue Panuon.UI.Silver development.    
Panuon.UI.Silver是一个完全开源的控件库。您的支持是项目得以发展的根本保证。

Zhifubao:  
支付宝：

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Global/zhifubao.jpg)

Paypal:  
paypal.me/Zeoun  


## Where is the exmaple ? （示例在哪？）
After downloading this repository, launch "Panuon.UI.Silver.Browser" project , and you will find it .  
当您下载该仓库后，只需启动"Panuon.UI.Silver.Browser"项目，即可看到示例。

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/step1.png)

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/temp.jpg)
### Work with helper （需要使用Helper的控件）:
Button / CheckBox / RadioButton / TextBox / PasswordBox / ComboBox / Expander / GroupBox / Expander

### Dependent custom controls （独立自定义控件）:
Calendar / Carousel / Loading / MultiSelector / ImageCuter / TagPanel / NeonLabel / Clock / DateTimePicker

### Styles only （仅样式）:
DataGrid / ScrollViewer (MiniScrollViewer)

# Button 

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/button.jpg)

# TextBox / PasswordBox

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/textbox.jpg)

# CheckBox

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/checkbox.jpg)

# RadioButton

![](https://raw.githubusercontent.com/Panuon/Panuon.Documents/master/Resources/Panuon.UI.Silver/radiobutton.jpg)
