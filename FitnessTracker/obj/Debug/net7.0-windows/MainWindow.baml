   M S B A M L   `   `   `  ????I  EFitnessTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FitnessTrackerFitnessTracker  5   	       FitnessTracker.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:FitnessTracker     5   	     ? Title$  
MainWindow??5   	   $	??600??6   $
??1050??6)    ? 
ResizeMode$ NoResize=?5	   	   .??5
      ? ???#333333 ? ColumnDefinitions 5   
   ?? 5      $??2* ?6   ?? 5      $??7* ?6   .+?5   
   ?? -   5        $??MaintContent??5   )   $??1??6   6)   ? 5   
   $??0??6    ? RowDefinitions 5      ?? 5      $??1.25* ?6    ?? 5      ?? 5      .+?5      &   System.Windows.Controls.Calendar  -   5        $??MainCal??5   ?   $??0??6      SelectionMode$ 
SingleDate=?6$   6N   ?? 5      -   5        $??
HomeButton??5      $??Dosis)?6'   $??1??6:   $
??Home??6G   ???#333333
???????$??22(?6   
???????6?   ?? 5      -   5        $??
DataButton??5      $??Dosis)?6'   $??2??6:   $??Data Analysis??6G   ???#333333
???????$??22(?6?   
???????6?   5      5      5       