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

## 2.0版本已在准备
更多样式，更好的表现，更少的BUG。  
2.0版本提供对Net Core 3.0的完全支持。几乎每种控件都增加了至少一种样式，或是进行了现有样式调整。  
全新的UIBrowser，帮助你快速设计控件，并生成样式或控件代码（尚在准备和优化中，可能会迟到）。  
2.0版本对现有控件库的代码进行了完全的重构，从根源上解决了一些BUG，并大幅减少了可能出现的Exception。从1.0版本升级到2.0版本需要修改约30%控件库相关代码，但这值得一试。  
请注意，2.0版本中不再集成FontAwesome。建议使用阿里的IconFont或其他图标字体。文档中会增加在WPF使用图标字体的帮助。  
完备的开发文档、代码示例与1.0升级指南（文档将转移到阿里的语雀平台）。  
预计将于1月底前发布beta版。尽请期待。  
你可以在上方切换2.0.0分支并下载开发版代码，但控件尚不齐全。
2.0文档参见：https://www.yuque.com/mochengvia/silver2.0

#### 2019-12-29 v1.0.9.5
解决了PUTextBlock抛出HorizontalContentAlightment异常的问题。
解决了DateTimePicker不能在选中日期后自动关闭的问题。可以将StaysOpen设置为False来阻止关闭。

#### 2019-11-14 v1.0.9.3 / v1.0.9.4
[重要]Button / RepeatButton 的重大优化：  
解决了无法使用AccessKey的问题；解决了除Standard外的样式无法使用UI控件作为Content的问题；优化了悬浮效果，不会再与Foreground和BorderBrush重叠显示。  
删除了ClickCoverBrush属性，新增了ClickCoverOpacity属性，默认值为0.8。    

[重要]关于TreeView的问题修复：  
目前Standard样式下，子项选中的前景色是与SelectedBackground属性关联的。新版本中，已调整为SelectedForeground属性。为所有的TreeView样式应用了SelectedForeground效果。  

#### 2019-11-13 v1.0.9.1 / v1.0.9.2
出于命名空间的重叠原因，TextBlock控件已重命名为PUTextBlock。  

#### 2019-11-12 v1.0.9
修复ColorPicker点击控件外区域时不能自动关闭的问题，新增了HeaderWidth属性。  
修复ColorSelector的SelectedBrush赋值为null时崩溃的问题。  
修复了LayoutHelper的RowDefinition无效的问题。  
修复了WaterfallPanel中的控件设置高度无效的问题。  
为Slider控件新增了Header和HeaderWidth属性。  
新增了CheckBox和RadioButton的Selector样式。  
新增了TextBlock控件。MatchText和MatchedForeground属性可以用来高亮指定的文字，AutoAdaptation和ExceededTextFiller属性可以将超出显示边界的文本显示为省略号或其他文字。[详见文档](
https://github.com/Panuon/Panuon.Documents/blob/master/Documents/PanuonUI.Silver/zh-cn.md#textblock-%E6%96%87%E6%9C%AC%E6%8E%A7%E4%BB%B6)。  
新增了AnimateWrapPanel控件，该控件继承自Panel。当其Children发生变化时，将产生一个重新排列的动画效果。[详见文档](  
https://github.com/Panuon/Panuon.Documents/blob/master/Documents/PanuonUI.Silver/zh-cn.md#animatewrappanel-%E5%8A%A8%E7%94%BB%E6%8D%A2%E8%A1%8C%E9%9D%A2%E6%9D%BF)。  
Timeline控件重做，新增TimelineItem控件。该控件默认启用虚拟化。[详见文档](  
https://github.com/Panuon/Panuon.Documents/blob/master/Documents/PanuonUI.Silver/zh-cn.md#timeline-%E6%97%B6%E9%97%B4%E8%BD%B4)。  
移除了TagPanel控件，新增了TagControl和TagItem控件。该控件不支持虚拟化。[详见文档](https://github.com/Panuon/Panuon.Documents/blob/master/Documents/PanuonUI.Silver/zh-cn.md#tagcontrol-%E6%A0%87%E7%AD%BE%E6%9D%BF)。   
  

#### 2019-11-6 v1.0.8.8
修复ComboBox的IsEditable属性设置为True时，Padding属性未对输入框生效的问题。  
修复ComboBox的BindToEnum属性在某些特定条件下可能报空指针异常，以及在使用BindToEnum属性时SelectedValue属性初始值无效的问题。  
新增了DataGridHelper中的SelectedItems属性。请注意，对该属性赋值是无效的。  

# ReleaseNote 发布文档  

https://github.com/Panuon/Panuon.Documents/blob/master/Documents/PanuonUI.Silver/release-note.zh-cn.md

# Document 文档

Chinese document(English document is still being written, you can translate it by google or other translators):  
中文文档：  
https://github.com/Panuon/Panuon.Documents/blob/master/Documents/PanuonUI.Silver/zh-cn.md

# Case 案例  

### Morin 魔音

http://www.huanghunxiao.com/  
  
![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/case_morin_4.png)  

### Collector 

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/case_collector_1.png)  

# Examples 示例  

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/window_1.png)

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/window_2.png)

# Donate  捐赠
Panuon.UI.Silver is an open source library.Your support will motivate me to continue Panuon.UI.Silver development.    
Panuon.UI.Silver是一个完全开源的控件库。您的支持是项目得以发展的根本保证。

Zhifubao:  
支付宝：

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/zhifubao.jpg)

Paypal:  
paypal.me/Zeoun  


## Where is the exmaple ? （示例在哪？）
After downloading this repository, launch "Panuon.UI.Silver.Browser" project , and you will find it .  
当您下载该仓库后，只需启动"Panuon.UI.Silver.Browser"项目，即可看到示例。

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/step1.png)

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/temp.jpg)
### Work with helper （需要使用Helper的控件）:
Button / CheckBox / RadioButton / TextBox / PasswordBox / ComboBox / Expander / GroupBox / Expander

### Dependent custom controls （独立自定义控件）:
Calendar / Carousel / Loading / MultiSelector / ImageCuter / TagPanel / NeonLabel / Clock / DateTimePicker

### Styles only （仅样式）:
DataGrid / ScrollViewer (MiniScrollViewer)

# Button 

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/button.jpg)

# TextBox / PasswordBox

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/textbox.jpg)

# CheckBox

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/checkbox.jpg)

# RadioButton

![](https://panuonui-silver-1252047526.cos.ap-chengdu.myqcloud.com/radiobutton.jpg)
