<a href="https://996.icu" target='_blank'><img src="https://img.shields.io/badge/link-996.icu-red.svg"></a>

# Panuon.UI.Silver
Panuon.UI optimized version. A beautiful wpf ui library using templates &amp; attached properties.  
Panuon.UI的优化版本。一个漂亮的、使用样式与附加属性的WPF UI控件库。

This is a developing program.  
这是一个正在开发的项目。

# Donate  捐赠
Panuon.UI.Silver is an open source library.Your support will motivate me to continue Panuon.UI.Silver development.    
Panuon.UI.Silver是一个完全开源的控件库。您的支持是项目得以发展的根本保证。

Zhifubao:  
支付宝：

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Global/zhifubao.jpg)

Paypal:  
paypal.me/Zeoun  


# Overview  总览
Blue theme (colors can be changed):  
蓝色主题（颜色都是可以修改的）：

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Panuon.UI.Silver/overview.jpg)

Pink theme :  
粉色主题：

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Panuon.UI.Silver/overview_2.jpg)


### Work with helper （需要使用Helper的控件）:
Button / CheckBox / RadioButton / TextBox / PasswordBox / ComboBox / Expander / GroupBox / Expander

### Dependent custom controls （独立自定义控件）:
Calendar / Carousel / Loading / MultiSelector

### Styles only （仅使用样式）:
DataGrid / ScrollViewer (MiniScrollViewer)

# Quick Start 开始使用

1. Add "Panuon.UI.Silver.dll" to your project references.  
将"Panuon.UI.Silver.dll"添加到你项目的引用中。

2. Append resource dictionary below to &lt;MergedDictionaries&gt; node in "App.xaml" , &lt;Window.Resources&gt; , or other resource nodes.  
将如下资源字典添加到App.xaml，&lt;Window.Resource&gt;或者其他资源节点下的&lt;MergedDictionaries&gt;中。
```
<ResourceDictionary Source="pack://application:,,,/Panuon.UI.Silver;component/Control.xaml" />
```              

3. Add reference in c#/xaml code  
在代码中添加引用。

```
(xaml)
xmlns:pu="clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.Silver"

(c#)
using Panuon.UI.Silver;
```

4. Try it:  
开始使用：
```
(xaml)
<Button x:Name="BtnTest" pu:ButtonHelper.ButtonStyle="Outline" />

(c#)
ButtonHelper.SetButtonStyle(BtnTest, ButtonStyle.Outline);
```

5. PanuonUI.Silver integrated with FontAwesome.Use it in your programs:  
PanuonUI.Silver内部集成了FontAwesome字体文件。你可以在你的项目中使用它：
```
(element property)
FontFamily="/Panuon.UI.Silver;component/Resources/#fontawesome"

(resource)
<FontFamily x:Key="IconFont">/Panuon.UI.Silver;component/Resources/#fontawesome</FontFamily>
...
FontFamily="{StaticResource IconFont}"
```
Copy icon from http://www.fontawesome.com.cn/cheatsheet  
从如上链接中拷贝图标。

# Document 文档
[Button](#Button-按钮)
[CheckBox](#CheckBox)
[RadioButton](#RadioButton)
[TextBox](#TextBox)
[PasswordBox](#PasswordBox)


## Button 按钮
ButtonHelper   
Namespace 命名空间: Panuon.UI.Silver  
Example 示例: 
```
<Button pu:ButtonHelper.ButtonStyle="Outline"
        pu:ButtonHelper.ClickStyle="Sink"
        Height="30"
        Width="120"/>  
```
Tips : For "Icon" property, You can set any control, fontawesome icon or image uri source to its value .Like this :  
提示：对于Icon属性，你可以对其赋值以任何控件、FontAwesome字体或图片URI资源。就像这样：
```
pu:ButtonHelper.Icon=""

pu:ButtonHelper.Icon="&#xf058;"

<pu:ButtonHelper.Icon>
    <Image Source="/Namespace;component/Resources/icon.jpg" Height="20" Width="20" />
</pu:ButtonHelper.Icon>

pu:ButtonHelper.Icon="/Namespace;component/Resources/icon.jpg"

```

Property Name | Property Type | Default Value | Description  
-|-|-|-
ButtonStyle | Enum(ButtonStyle) | Standard[/Outline/Hollow/Link] | gets or sets base button style . 获取或设置按钮样式。|
ClickStyle | Enum(ClickStyle) | None[/Sink] | gets or sets click effect of the button . 获取或设置按钮的点击效果。|
Icon | Object | Null | gets or sets icon of the button, which placed before the content . 获取或设置按钮的Icon，它将被放置在Content之前。| 
CornerRadius | CornerRadius | (0,0,0,0) | gets or sets border corner radius of the button . 获取或设置按钮的边框圆角。|
HoverBrush | Brush | #3E3E3E | gets or sets background("Standard" style ,background and borderbrush in "Hollow" Style, foreground and borderbrush in "Outline" style, foreground in "Link" style) of the button when mouse enter . 获取或设置当鼠标进入时，按钮的背景色（在Standard样式下。Hollow样式下将改变背景色与边框，Outline样式下将改变前景色与边框，Link样式下将改变前景色）|
ClickCoverBrush | Brush | #22FFFFFF | gets or sets cover mask of the button when mouse clicked . 获取或设置当鼠标点击时，按钮的遮罩层。|
IsWaiting | Boolean | False | gets or sets whether the button is in waiting mode .Button will be disabled when IsWaiting="True". 获取或设置按钮是否处于等待状态。进入等待模式时，该按钮会被禁用。|
WaitingContent | Object | "Please wait..." | gets or sets content of the button when IsWaiting="True". 获取或设置当按钮进入等待状态时，显示的内容。|

## CheckBox
## RadioButton
## TextBox
## PasswordBox


