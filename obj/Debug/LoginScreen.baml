   M S B A M L   `   `   `  ����  WVCCTestApp    WVCCTestApp.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  WVCCLoginWindow��5   	    � Title$ Login Screen��5   	   $	��450��5   	   $	��750��5   	    � WindowStyle$ ThreeDBorderWindow=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
 J� Uid$ LoginWindow��5	   	    J� CommandBindings 5
      .��5      � -   5         �Name$ Grid2��5      $��0,0,0,0q�5      $��Disabled=�5      $	��798��5      $	��663��5      $
��1440��5      $	��900��5       J� RenderTransformOrigin$ 0.413,0.139&�5       � RowDefinitions 5   
   �� 5      $
��356* �6   �� 5      $
��124* �6   �� 5      $
��183* �6   ��5   
   �� 5      	 �� EndPoint$
	 .5,1&�6"   
 � MappingMode$
 RelativeToBoundingBox=�5   "    �� 
StartPoint$	 0,0&�5   "   .��5       �  � Color$ black��6    � Offset$ 1Q�5!      � 5"      $ 	#FF5194F3��6   5#      .+�5%   
   �� $��	Underline{�6   $��2��60   $��-13,-14,0,1q�6A   B� 6X   .�6c   �� .F�5&      �� -   5         ��Name$ Login_Screen��5&      $��WVCC Login Screen��5'      $��Center=�5(      $��44��5)      $��213,26,293,0q�6   $	��Top=�5*      $	��292��5+      $��22(�5,      $��Center=�5-      $��1,1,1,0q�5.      ���	#FFCDCDCD$
��Bold"�50      51      6!   6-   �� 53   
   -   5         ��Name$ Loginbtn��53      $��Enter��54      $
��Left=�56      $��58��57      $��601,298,0,0q�6   $	��Top=�58      $	��118��59      $��22(�5:      $
��Bold"�5;      ���	#FFCDCDCD5<      	� 5=   
   -   5         	�Name$ 	Shift1rdo��5=      $��Shift 1: 8:00AM - 6:30PM��5>      $
��Left=�5?      $��
33,174,0,0q�5@      $	��Top=�5A      $	��175��5B      $��18��6   ���	#FFF9F7F7$��SemiBold"�5D       	� 	GroupName$ 
GroupShift��5E      	� 5F   
   -   5        $ 	Shift2rdo��5F      $��Shift 2: 8:00AM - 4:30PM��5G      $
��Left=�5H      $��
33,208,0,0q�5I      $	��Top=�5J      $	��175��5K      ���	#FFF9F7F7$��SemiBold"�5M      $ 
GroupShift��5N      	� 5O   
   -   5        $ 	Shift3rdo��5O      $��Shift 3: 10:00AM - 6:30PM��5P      $
��Left=�5Q      $��
33,241,0,0q�5R      $	��Top=�5S      $	��175��5T      ���	#FFF9F7F7$��SemiBold"�5V      $ 
GroupShift��5W      �� 5X   
   -   5        $ Shift_Label��5X      $?��9Shift: All times listed in EST
    (You Must Choose One)��5Y      $
��Left=�5Z      $��45��5[      $��
33,105,0,0q�6   $	��Top=�5\      $	��175��5]      ���	#FFCDCDCD$��Medium"�5_      $��Center=�5`      	� 5a   
   -	   5        $ 	Shift4rdo��5a      $ ��Shift 4: 11:30AM - 10:00PM��6)   $
��Left=�5b   
   $��
33,273,0,0q�5c   
   $	��Top=�5d   
   $	��175��5e   
   ���	#FFF9F7F7$��SemiBold"�5g   
   $ 
GroupShift��6    �� 5h   
   -
   5        $ Daily_Assignment_Label��5h      $4��.      Daily Assignment 
(You Must Choose One)��5i   
   $
��Left=�5j   
   $��45��5k   
   $��245,105,0,0q�6   $	��Top=�5l   
   $	��175��5m   
   ���	#FFCDCDCD$��Medium"�5o   
   $��Center=�5p      �� 5q   
   -   5        $! Daily_Assignment_Label_Copy��5q      $/��)Count Of Veterans in 
   Each Assignment��5r   
   $
��Left=�5s   
   $��45��5t   
   $��455,105,0,0q�6   $	��Top=�5u   
   $	��175��5v   
   ���	#FFCDCDCD$��SemiBold"�5x   
   $��Center=�5y      $��Center=�5z      	� 5{   
   -   5        $ 	NewVetrdo��5{      $��1: New Veterans��5|   
   $
��Left=�5}   
   $��245,174,0,0q�5~   
   $	��Top=�5   
   $	��175��5�   
   $��18��6   ���	#FFF9F7F7$��SemiBold"�5�   
   $ GroupAssign��5�      	� 5�   
   -   5        $ BaselineVetrdo��5�      $��2: Baseline Veterans��5�   
   $
��Left=�5�   
   $��245,208,0,0q�5�   
   $	��Top=�5�   
   $	��175��5�   
   $��18��6   ���	#FFF9F7F7$��SemiBold"�5�   
   $ GroupAssign��5�      	� 5�   
   -   5        $ FollowVetrdo��5�      $��3: Follow-Up Veterans��5�   
   $
��Left=�5�   
   $��245,241,0,0q�5�   
   $	��Top=�5�   
   $	��175��5�   
   $��18��6   ���	#FFF9F7F7$��SemiBold"�5�   
   $ GroupAssign��6    	� 5�   
   -   5        $ InboundVetrdo��5�      $,��&4: Inbound and ALL Others             ��5�   
   $
��Left=�5�   
   $��245,271,0,0q�5�   
   $	��Top=�5�   
   $	��175��5�   
   $��18��6   ���	#FFF9F7F7$��SemiBold"�5�   
   $ GroupAssign��6    �� 5�   
   $
��New:��6   $
��Left=�5�      $��27��5�      $��455,174,0,0q�5�      $	��Top=�5�      ���	#FFF9F7F7$��87��5�      $
��Bold"�6   �� 5�   
   $��	Baseline:��6   $
��Left=�5�   
   $��27��5�   
   $��455,208,0,0q�5�   
   $	��Top=�5�   
   ���	#FFF9F7F7$��87��5�   
   $
��Bold"�5�      �� 5�   
   $��
Follow-Up:��6   $
��Left=�5�   
   $��27��5�   
   $��455,240,0,0q�5�   
   $	��Top=�5�   
   ���	#FFF9F7F7$��87��5�   
   $
��Bold"�5�      �� 5�   
   -   5         ��Name$ 
NewCountbx��5�      $
��Left=�5�      $��27��5�      $��570,174,0,0q�5�       �� TextWrapping$
 Wrap=�5�      $	��New��5�       �� TextAlignment$ Center=�5�      $
��Bold"�5�      $	��Top=�5�      $��60��5�      �� 5�   
   -   5        $ BaselineCountbx��5�      $
��Left=�5�      $��27��5�      $��570,208,0,0q�5�      $
 Wrap=�5�      $ Center=�5�      $��Baseline��5�      $
��Bold"�5�      $	��Top=�5�      $��60��5�      �� 5�   
   -   5        $ FollowCountbx��5�      $
��Left=�5�      $��27��5�      $��570,241,0,0q�5�      $
 Wrap=�5�      $��Followup��5�      $ Center=�5�      $
��Bold"�5�      $	��Top=�5�      $��60��5�      $ 0.562,1.074&�5�      5�      5�      