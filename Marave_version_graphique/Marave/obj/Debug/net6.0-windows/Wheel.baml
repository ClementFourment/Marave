   M S B A M L   `   `   `  ????A  =Marave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MaraveMarave  5          Marave.Wheel   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Marave     5        N? Title$  Wheel??5	      .??5      ? .+?5   
   ?? -   5         ??Name$ wheel??5      $	??300??6   $??Center=?6+   $??Center=?6H   $??0,0,0,98q?6c   ??5      ?? 5       ?? DecodePixelWidth$	 300??6    ?? 	UriSource$( "/Marave;component/images/wheel.png??65   5      ?? 5   
   -   5         ??Name$ pointerContainer??5      $	??150??6.   $	??180??6:   $??0,0,0,30q?6G    J? RenderTransformOrigin$ 
0.51,0.315&?6Y   z?5      V? 5      .~?5      ?? ?? 5      ?? 5       ?? Angle$ 0Q?6&   T? 5      5      ??5      ?? 5      -   5        pointer?? ?? ImageSource$0 */Marave;component/images/wheel-pointer.png??5   .    j? 
AlignmentX$ Center=?6g   5      5      ?? 5   
   -   5        	 ??Name$	 throw_wheel??5       $??Tourner la roue??5!      
???????$??14(?5$      $??Medium"?5%      $??
0 250 0 10q?5&      
 ? Cursor$

 Hand??6!    J? Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         
BlurRadius$ 20Q?6#   ??5+      ?? 5,       ?? 
TargetType" ??6   .?5-      ??  ?? Property ? ?? ?? Value ?#FE658463   ?? 5.       ?@?Cursor$
 Hand??6/    ?? Triggers 5/      P? 50       P? Property ?@J?IsMouseOver P? Value$
 True??69   . ?51      ??  ? ?? ?#FF4C706;   52      54      ??56      ?? 57       ?? 
TargetType" ??6"   .R?58      ?? $	??150??6   $??30??6)    ?? CornerRadius$ 12??59   %   #??z??5:   %   ._?5;      ?? $??Center=?6+   $??Center=?5<   3   5=      5>      5@      5A      5B      