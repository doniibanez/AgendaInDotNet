   M S B A M L   `   `   `  ����A  =Agenda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AgendaAgenda  5   	       Agenda.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Agenda     5   	   -   5          � Title$  Agenda Desktop v0.0��5   	   $	��600��6%   $	��800��62    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T   .��5	      � .+�5
   
   �� $��ID��6   $
��Left=�6   $��	10,10,0,0q�68   $	��Top=�6K   �� 5   
   -   5         ��Name$ txtID��5      $
��Left=�6!   $��23��6<   $��	10,41,0,0q�6H    �� TextWrapping$
 Wrap=�6[   $	��Top=�6o   $	��120��6�   {�.  6�   �� 5   
   $
��Nome��6   $
��Left=�6   $��	10,69,0,0q�6:   $	��Top=�6M   �� 5   
   -   5        $ txtNome��5      $
��Left=�6#   $��23��6>   $��	10,95,0,0q�6J   $
 Wrap=�6]   $	��Top=�6q   $	��772��6�   �� 5   
   $��Telefone��6   $
��Left=�6#   $��
10,128,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ txtTelefone��5      $
��Left=�6'   $��23��6B   $��
10,154,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $	��772��6�   �� 5   
   $��Email��6   $
��Left=�6    $��
10,187,0,0q�6;   $	��Top=�6O   �� 5   
   -   5        $ txtEmail��5      $
��Left=�6$   $��23��6?   $��
10,213,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��772��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dgContatos��5      $
��Left=�6'   $	��243��6B   $��
10,316,0,0q�6O   $	��Top=�6c   $	��772��6{      
IsReadOnly . 6�   �� 5   
   -   5        $��
btnInserir��5      $��Inserir��6#   $
��Left=�65   $��143,247,0,0q�6P   $	��Top=�6e   $��83��6}   $��31��6�   6�   �� 5   
   -   5        $��
btnAlterar��5      $��Alterar��6#   $
��Left=�65   $��231,247,0,0q�6P   $	��Top=�6e   $��83��6}   $��31��6�   {�.  6�   �� 5   
   -	   5        $��btnLocalizar��5      $��	Localizar��6%   $
��Left=�69   $��319,247,0,0q�6T   $	��Top=�6i   $��83��6�   $��31��6�   6�   �� 5   
   -
   5        $��
btnExcluir��5      $��Excluir��6#   $
��Left=�65   $��495,247,0,0q�6P   $	��Top=�6e   $��83��6}   $��31��6�   {�.  6�   �� 5   
   -   5        $��	btnSalvar��5      $��Salvar��6"   $
��Left=�63   $��407,247,0,0q�6N   $	��Top=�6c   $��83��6{   $��31��6�   {�.  6�   �� 5   
   -   5        $��btnCancelar��5      $��Cancelar��6$   $
��Left=�67   $��583,247,0,0q�6R   $	��Top=�6g   $��83��6   $��31��6�   {�.  6�   �� 5   
   -   5        $��
lbTotalReg��5      $
��Left=�6"   $��
10,289,0,0q�6=   $	��Top=�6Q   $	��772��6i   $��22��6u   $��11(�6�   5      5      