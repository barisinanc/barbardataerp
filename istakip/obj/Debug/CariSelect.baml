   M S B A M L   `   `   `  ����  	ERPStudyo    istakip.CariSelect   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      6my-http://schemas.microsoft.com/wpf/2008/toolkit  5      $	��386��6?   $	��636��6O   .��5      � 
�������.+�5   
   )  #Microsoft.Windows.Controls.DataGrid  -   5        $��dataGridSearch��5   E       AutoGenerateColumns  .  $��	0,167,1,3q�62      
IsReadOnly .    SelectionMode$ Single=�6m      CanUserSortColumns .  6�   � 5   
   -   5        $��grid1��5   H   $	��132��6   $
��Left=�6   $��2,0,0,0q�67   $	��Top=�6U   $	��313��6m   .+�5      �� -   5        $��textBoxAdSoyad��5   P   $��23��6   $
��Left=�6"   $��	92,34,0,0q�6=   $	��Top=�6f   $	��120��6~   k gTelerik.Windows.Controls.Input, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=5803cfa389c90ce7/  )Telerik.Windows.Controls.RadMaskedTextBox  5	      a ]Telerik.Windows.Data, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Etelerik1http://schemas.telerik.com/2008/xaml/presentation     6h   -   5        $��textBoxCepTel��5	   G   $��24��6'   $��
93,65,0,43q�63   $	��119��6\      Mask$ # (###) ### ####��6�    � OverridesDefaultStyle .  $
��Left=�6�   |�.  ��.  J� IsHitTestVisible . 6    5
      Etelerik1http://schemas.telerik.com/2008/xaml/presentation     6�   -   5        $��
textBoxTel��5
   `   $��24��6'   $��	93,0,0,11q�63   $ # (###) ### - ####��6F    .  $��Bottom=�6�   $	��119��6�   $
��Left=�6�   |�.  ��. 6&  �� 5      -   5        $��label1��5   N   $��28��6   $
��Left=�6    $��	10,34,0,0q�6;   $	��Top=�6\   $��97��6t   .��6   	Ad Soyad:6�   �� 5      -   5        $��label2��5   C   $
��Left=�6   $��
10,63,0,41q�6/   $��86��6Q   .��6\   Cep Telefonu:6k   �� 5      -   5        $��label3��5   N   $��28��6   $
��Left=�6    $��	10,97,0,0q�6;   $	��Top=�6\   $��97��6t   .��6   Sabit Telefon:6�   �� 5      -	   5        $��buttonSearch��5   J   $��Right=�6   $��0,62.48,6,46.52q�61   $��75��6^   .��6�   Ara6�   �� 5      -
   5        $��labelCariStatus��5   4   $��28��6   $��
11,3,136,0q�6    $	��Top=�6K   .��6c   Yeni Müşteri6q   �� 5      -   5        $��buttonClear��5   N   $��23��6   $��Right=�6!   $��0,0,6,7q�6=   $��Bottom=�6a   $��75��6|   .��6�   	Temizle6�   5      �� 5   
   -   5        $��
buttonSave��5   L   $��87��6   $��Right=�6   $��	0,12,12,0q�69   $	��Top=�6^   $	��113��6v   .��6�   Kaydet6�   �� 5   
   -   5        $��buttonSearchCancel��5   1   $��27��6   $��
0,105,12,0q�6   $	��Top=�6K   $��Right=�6c   $	��113��6   .��6�   İptal6�   �� 5   
   -   5        $��buttonSearchSelect��5   L   $��23��6   $
��Left=�6   $��
12,138,0,0q�68   $	��Top=�6f   $��75��6~   .��6�   Seç6�   5      5      