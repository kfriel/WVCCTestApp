   M S B A M L   `   `   `  ����  WVCCTestApp     WVCCTestApp.OutboundSurvey   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  WVCCOutboundScript��5   	    � Title$ Outbound Script��5   	   $	��820��5   	   $
��1200��5   	    � WindowStyle$ ThreeDBorderWindow=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
 J� Uid$ OutboundSurvey��5	   	   .��5
      � -   5         �Name$ Grid2��5
      $��	0,0,0,-20q�5      $��Disabled=�5      $	��798��5      $	��663��5      $
��1200��5      $	��820��5       J� RenderTransformOrigin$ 0.413,0.139&�5       � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $	��243 �6   �� 5      $	��243 �6   �� 5      $��3* �6   ��5   
   �� 5      	 �� EndPoint$
	 .5,1&�6"   
 � MappingMode$
 RelativeToBoundingBox=�5   "    �� 
StartPoint$	 0,0&�5   "   .��5       �  � Color$ black��6    � Offset$ 1Q�5!      � 5"      $ 	#FF5194F3��6   5#      .+�5%   
   �� $��	Underline{�6   $��	0,-14,0,1q�60   $��2��6C   B� 5&      �� 6   .F�5'   	   �� -   5         ��Name$ OutboundScript��5'      $��WVCC Outbound Script��5(   	   $��Center=�5)   	   $��44��5*   	   $��300,26,300,0q�6   $	��Top=�5+   	   $
��1100��5,   	   $��26(�5-   	   $��Center=�5.   	   $��1,1,1,0q�5/   	   ���	#FFCDCDCD$
��Bold"�51   	   52   	   6   �� 53   
   $��Label��6   $ 
8.55,6.427&�54      $��2��55      $��376,13,322,178q�56      $��1��57      �� 58   
   -   5         ��Name$ Close��59      $��2��5;      $
��NEXT��5<      $
��Left=�5=      $��85��5>      $��1046,126,0,0q�5?      $��3��5@      $	��Top=�5A      $	��124��5B      $
��Bold"�5C      $��22(�5D      ��5E      �� 5F      $	 0.5,1&�6&   $
 RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5G      � $ 	#FFF3F3F3��6#   $ 1Q�65   � 5H      $ 	#FFDDDDDD��6#   $	 0.5Q�65   � 5I      $ 	#FFEBEBEB��6#   $	 0.5Q�65   � 5J      $ 	#FFE67171��6#   $ 0.974Q�65   5K      5M      �� 5N   
   -   5        $ 
Close_Copy��5O   
   $��2��5Q   
   $
��BACK��5R   
   $
��Left=�5S   
   $��85��5T   
   $��917,126,0,0q�5U   
   $��3��5V   
   $	��Top=�5W   
   $	��124��5X   
   $
��Bold"�5Y   
   $��22(�5Z   
   ��5[      �� 5\      $	 0.5,1&�6&   $
 RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5]      � $ 	#FFF3F3F3��6#   $ 0Q�65   � 5^      $ 	#FFEBEBEB��6#   $	 0.5Q�65   � 5_      $ 	#FFDDDDDD��6#   � 5`      $ 	#FFE67171��6#   $ 1Q�65   5a      5c      �� 5e   
   -   5         ��Name$ Answer1onPage��5f      $��2��5g      $
��Left=�5h      $	��115��5i      $��
43,109,0,0q�5j      $��1��5k      
���   �$	��Top=�5m      $	��856��5n      ���	#FFF4F4F55o      �� 5p   
   -   5        $ Answer2onPage��5q      $��2��5r      ���	#FFF4F4F5$
��Left=�5t      $	��115��5u      $��
43,109,0,0q�5v      $��2��5w      
���   �$	��Top=�5y      $	��856��5z      �� 5|   
   -   5        $ Answer3onPage��5}      $��2��5~      ���	#FFF4F4F5$
��Left=�5�   
   $��43,106,0,31q�5�   
   $��3��5�   
   
���   �$	��856��5�   
   �� 5�   
   $��2��5�      $
��Left=�5�      $��28��5�      $��
967,19,0,0q�5�       �� TextWrapping$
 Wrap=�5�      $��RESPONDENTID WILL GO HERE��5�      $	��Top=�5�      $	��400��5�      $
��Bold"�5�      �� 5�   
   -	   5         ��Name$ 	Question1��5�      $��2��5�      $
��Left=�5�      $	��104��5�      $��43,0,0,0q�5�      $��1��5�      $
 Wrap=�5�      $��TextBox��5�      ���	#FFCDCDCD$��Medium"�5�      $	��Top=�5�      $	��856��5�      $��18(�5�       �� TextAlignment$
 Left=�5�      �� 5�   
   -
   5        $ 	Question2��5�   
   $��2��5�   
   $
��Left=�5�   
   $	��104��5�   
   $��43,0,0,0q�6   $��2��5�   
   $
 Wrap=�5�   
   $��TextBox��5�   
   ���	#FFCDCDCD$��Medium"�5�      $
 Left=�5�      &   System.Windows.Media.TextOptions   TextRenderingMode$ 	ClearType=�5�      $	��Top=�5�   
   $	��856��5�   
   $��18(�6   �� 5�   
   -   5        $ 	Question3��5�   
   $��2��5�   
   $
��Left=�5�   
   $	��101��5�   
   $��43,0,0,0q�6   $��3��5�   
   $
 Wrap=�5�   
   $��TextBox��5�   
   ���	#FFCDCDCD$��Medium"�5�      $	��Top=�5�   
   $	��856��5�   
   $��18(�5�      	� 5�   
   -   5         	�Name$ Q1A1rdo��5�      $��2��5�      ���	#FFCDCDCD$
��Bold"�5�      $
��Left=�5�      $��
80,120,0,0q�5�      $��1��5�      $	��Top=�5�      $	��300��5�      $��22��5�       J� SnapsToDevicePixels . $��16(�5�      	� 5�   
   -   5        $ Q2A1rdo��5�      $��2��5�      $
��Bold"�5�      ���	#FFCDCDCD$
��Left=�5�      $��
80,121,0,0q�5�      $��2��5�      $	��Top=�5�      $	��300��5�      $��22��5�       . $��16(�5�      	� 5�   
   -   5        $ Q2A2rdo��5�      $��2��5�      $
��Bold"�5�      ���	#FFCDCDCD$
��Left=�5�      $��
80,148,0,0q�5�      $��2��5�      $	��Top=�5�      $	��300��5�      $��22��5�       . $��16(�5�      	� 5�   
   -   5        $ Q2A3rdo��5�      $��2��5�      $�� ��5�      $
��Bold"�5�      ���	#FFCDCDCD$
��Left=�5�      $��
80,170,0,0q�5�      $��2��5�      $	��Top=�5�      $	��300��5�      $��44��5�       . $��16(�5�      	� 5�   
   -   5        $ Q2A4rdo��5�      $��2��5�      ���	#FFCDCDCD$
��Left=�5�      $
��Bold"�5�      $��402,123,0,0q�5�      $��2��5�      $	��Top=�5�      $	��300��5�      $��22��5�       . $��16(�5�      	� 5�   
   -   5        $ Q2A5rdo��5�      ���	#FFCDCDCD$
��Bold"�5�      $
��Left=�5�      $	��Top=�5      $	��300��5     $��22��5      . $��16(�5     $��2��5     $��402,150,0,0q�5     $��2��5     	� 5  
   -   5        $ Q2A6rdo��5	     ���	#FFCDCDCD$
��Bold"�5     $
��Left=�5     $	��Top=�5     $	��300��5     $��22��5      . $��16(�5     $��2��5     $��402,177,0,0q�5     $��2��5     	� 5  
   -   5        $ Q3A1rdo��5     $��2��5     ���	#FFCDCDCD$
��Bold"�5     $
��Left=�5     $��
80,129,0,0q�5     $��3��5     $	��Top=�5     $	��300��5     $��22��5      . $��16(�5!     	� 5"  
   -   5        $ Q3A2rdo��5#     $��2��5$     ���	#FFCDCDCD$
��Bold"�5&     $
��Left=�5'     $��
80,156,0,0q�5(     $��3��5)     $	��Top=�5*     $	��300��5+     $��22��5,      . $��16(�5.     �� 50  
   -   5        $ 	xaml_code��51     $��2��52     $
��Left=�53     $	��103��54     $��
954,65,0,0q�55     $��1��56     $
 Wrap=�57     $��TextBox��58     $	��Top=�59     $	��182��5:     �� 5=  
   -   5         ��Name$ contentControl��5=     5?     5A     