   M S B A M L   `   `   `  ????I  EFitnessTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FitnessTracker.ControlsFitnessTracker.Controls  5      -    'FitnessTracker.Controls.EditMealControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:FitnessTracker.Controls     5      .??5	      ? ???#333333  ? ColumnDefinitions  5
   
   ?? 5      $	??500 ?6   ?? 5      $??30 ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $	??240 ?6   ?? 5      $	??210 ?6   .+?5   
   ? $??1??6    5      ?? 5      $??30 ?6    ?? 5      $??30 ?6    ?? 5      $??30 ?6    ?? 5      $??30 ?6    ?? 5      $??30 ?6    ?? 5      $??30 ?6    ?? 5      $??30 ?6    ?? 5       $??30 ?6    .+?5#      3  -System.Windows.Controls.Ribbon.RibbonCheckBox  -   5        $??Row1Box??5#   +   $??0??6   6+     5$      -   5        $??Row2Box??5$   +   $??1??6   6+     5%      -   5        $??Row3Box??5%   +   $??2??6   6+     5&      -   5        $??Row4Box??5&   +   $??3??6   6+     5'      -   5        $??Row5Box??5'   +   $??4??6   6+     5(      -   5        $??Row6Box??5(   +   $??5??6   6+     5)      -   5        $??Row7Box??5)   +   $??6??6   6+     5*      -   5        $??Row8Box??5*   +   $??7??6   6+   5+      ? 5-   
   $??2??6    5.      ?? 5/      ?? 50      .+?53      ?? -	   5        $??CaloriesBlock??53   %   $??1??6   $??Dosis)?6:   $??24(?6M   $??
Calories: ??6[   $
??Left=?6m   $??Center=?6?   
???????6?   ?? 55      -
   5        $??DelFoodButton??55      ???#333333$??Delete Food??6?   $??Dosis)?6U   
???????$??Center=?6{   $??Center=?6?   $??24(?6?   
???  ??6?   ?? 56      -   5         ??Name$ DataBox??56   *   $??1??6   6*   58      ? 5:   
   $??1??6   $??2??6    5;      ?? 5<      ?? 5=      ?? 5>      ?? 5?      .+?5B      ?? -   5        $??AddFoodButton??5B      ???#333333$??Add Food??6?   
???????$??Dosis)?6e   $??24(?6x   
???2?2?6?   ?? 5C      -   5        $??AddFromFileButton??5C   "   $??1??6   ???#333333$??Add From File??6P   
???????$??Dosis)?6{   $??24(?6?   
????? ?6?   ?? 5D      -   5        $??SaveFoodButton??5D   "   $??2??6   ???#333333$??	Save Food??6M   
???????$??Dosis)?6t   $??24(?6?   
????  ?6?   ?? 5E      -   5        $??
BackButton??5E   "   $??3??6   ???#333333$
??Back??6I   
???????$??Dosis)?6k   $??24(?6~   
???  ??6?   5F      ?? 5H   
   -   5        $??FoodList??5H   '   ???#333333)   #FitnessTracker.Controls.FoodControl  5J   
   -   5          Name$ InputControl??5J   )   $??1??6   6)   5K      5L      