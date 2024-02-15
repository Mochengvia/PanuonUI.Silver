<a href="https://996.icu" target='_blank'><img src="https://img.shields.io/badge/link-996.icu-red.svg"></a>
<a href="https://996.icu" target='_blank'><img src="https://camo.githubusercontent.com/8948ee9e753309fa3e978b3a0bdeda5a0c3f98ec/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f2e6e65742d253345253344342e302d626c75652e737667"></a>

# 出于历史包袱原因，此控件库已不再维护。如果发现了bug，请将merge request提交至仓库。

## 全新的 Panuon.WPF.UI 现已发布。
https://github.com/PanuonGroup/Panuon.UI.Silver  

自Panuon.UI.Silver 2.2开始，控件库已更名为 `Panuon.WPF.UI`。 新控件库提供了非常详细的细节自定义功能，如果你刚刚接触WPF，可能会遇到一点困难。如果你是WPF专家，它则会让你感到惊喜（比如丰富的自定义属性以及残缺的文档  
如果想查看视频教程，欢迎关注我的bilibili账号：https://space.bilibili.com/319290241  

# Panuon.UI.Silver
Panuon.UI optimized version. A beautiful wpf ui library using templates &amp; attached properties.  
Panuon.UI的优化版本。一个漂亮的、使用样式与附加属性的WPF UI控件库。

Email : mochengvia@panuon.com  
QQ频道 : https://pd.qq.com/s/fpap7qj2y

GitHub地址：https://github.com/Panuon/PanuonUI.Silver  
码云地址： https://gitee.com/panuon/PanuonUI.Silver  

Panuon Iconfont已在阿里图标字体库开放。你可以在1.x版本中使用这些图标。  
https://www.iconfont.cn/user/detail?spm=a313x.7781069.1998910419.d9bd4f23f&uid=4788435

#### 20202-5-26 V1.1.3
修复ComboBox的Padding右边距过大造成的显示问题。  
修复在修改MenuHelper.SubmenuWidth属性时出现的显示异常BUG。
修复PendingBox无法从CenterOwner启动的BUG。 

#### 20202-5-7 V1.1.2
优化ComboBox的阴影效果。  
修复在TreeView的Chain样式中，即使子项内没有子项也能展开的BUG。  
修复Slider控件的显示效果。  

#### 20202-4-16 V1.1.1
[重要修复]修复了Button和RepeatButton无法换肤的问题。此问题是由于Foreground、Background、BorderBrush属性在动画执行结束时，没有释放对属性的占用，从而导致无法再更改这些属性的值。现已使用2.0的Button解决方案替代。  
PUTextBlock已更名为TextBlockX。若要使用ClipToBounds效果，必须使TextBlockX或其容器拥有可计算的高度以及宽度。此外，修复了TextBlockX在极端情况下可能死循环的问题。  


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
