   M S B A M L   `   `   `  ????A  =Marave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MaraveMarave  5   	       Marave.Game   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Marave     5   	     ? 
ResizeMode$  NoResize=?5   	    ? Title$
 Game??5	   	   $	??600??6   $
??1000??6#   ???	#FF8B62E8.??5      ? ??5   
   ?? 5      -   5        
background?? ?? ImageSource$- '/Marave;component/images/background.png??5   -    j? 
AlignmentX$ Center=?6c    j? 
AlignmentY$ Center=?6w    ?? 	Transform 5      V? 5      .~?5      ??  ?? ScaleY$ 1Q?6)    ?? ScaleX$ 16Q?64   ?? 5      ?? 5       ?? Angle$ 0Q?6*   T? 5      	 T? X$	 0Q?6-   5      
 ?? RelativeTransform
 5      V? 5      .~?5      ??  ?? CenterY$	 0.5Q?6)    ?? CenterX$	 0.5Q?67   ?? 5       ?? CenterX$	 0.5Q?6(    ?? CenterY$	 0.5Q?66   ?? 5      $ 0Q?6*    ?? CenterX$	 0.5Q?64    ?? CenterY$	 0.5Q?6B   T? 5      5      5      .+?5"   
   ?? -   5         ??Name$
 hero??5"      $	??300??6   $??Center=?6*   $??Center=?6G   $??0,165,360,0q?6b   ??5#      ?? 5$       ?? DecodePixelWidth$	 300??6    ?? 	UriSource$. (/Marave;component/images/hero_idle_9.png??65   5&       ? 5(   
   -   5          ?Name$ frame??5(        ? Source$  ??6   $	??600??6)   $	??500??65     ? NavigationUIVisibility$ Hidden=?6B   $??0q?6b    K? ZIndex$	 200??6v   5*       ? 5+   
   -   5        $ 	frameRoom??5+      $  ??6#   $ Hidden=?6-   $??0q?6M   $	 200??6a   5-      ?? 5/   
   -   5         ??Name$ heroHealthText??5/      $??50??6,   $??25??67   $??100/100??6C   
???????$	 100??6e    ?? TextAlignment$ Center=?6x   $??Center=?6?   $??Center=?6?   $??
0,0,365,26q?6?   ? 51   
   -   5         ?Name$ 
heroHealth??51      $??Center=?6*   $??Center=?6G   $??10??6b   $??100,0,480,35q?6n   $	??100??6?   ???	#FFFF0E0E???	#FF1F1F1F???	#FF232323 J? Effect 52      3  -System.Windows.Media.Effects.DropShadowEffect  53         ShadowDepth$ 2Q?6#      
BlurRadius$ 2Q?63   55      ?? 56   
   $??20??6   $??Center=?6   $??Center=?68   $??
0,0,480,35q?6S    57        58      $ 2Q?6#   $ 2Q?63   ??5:      ?? 5;      $	 300??6   $( "/Marave;component/images/heart.png??65   5=      ?? 5?   
   -   5        $
??Left=?5?      $	??Top=?6,   $??	10,10,0,0q?6D   
?????? $??0q?6~    ? Cursor$
 Hand??6?   .??5@      ?? -   5        $	 son??5@      $??60??6!    5A        5B      $ 2Q?6'   $ 2Q?67   ??5D      ?? 5E      $	 300??6"   $( "/Marave;component/images/sound.png??69   5G      ??5H      ?? 5I       ?? 
TargetType" ??6   .?5J      ??   ?? Property  ? ??! ?? Value! ?	#FFBDBDBD63   ?? 5K        ?@?Cursor$
! Hand??6/   " ?? Triggers" 5L      P? 5M      # P? Property# ?@J?IsMouseOver$ P? Value$
$ True??69   . ?5N      ??   ? ??
! ??  ?6;   5O      5Q      ??5S      ?? 5T      % ?? 
TargetType"% ??6"   .R?5U      ?? $??60??6   $??60??6(   #??z??5V   %   ._?5W      ?? $??Center=?6+   $??Center=?5X   3   5Y      5Z      5\      5]      5^      