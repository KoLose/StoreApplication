<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:models="using:Domain.Models"
             mc:Ignorable="d" d:DesignWidth="800" d:DesignHeight="450"
             x:Class="AvaloniaApplication.Pages.ProductPage.ProductUC">
    <DataGrid x:Name="ItemsGrid"
              Margin="10"
              IsReadOnly="True"
              AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="ID" Binding="{Binding Id}" Width="60"/>
            
            <!-- Колонка с чекбоксом (из PR #18) -->
            <DataGridTemplateColumn Header="Наименование" Width="260">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate x:DataType="models:Product">
                        <CheckBox IsChecked="{Binding IsBought}"
                                  Content="{Binding Name}"
                                  Margin="8,0"
                                  Click="OnBoughtClick"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            
            <DataGridTemplateColumn Header="Действия" Width="150">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <UniformGrid Columns="2">
                            <Button Content="Добавить в список" Click="AddToList_Click"/>
                            <Button Content="Удалить" Click="RemoveFromList_Click"/>
                        </UniformGrid>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
</UserControl>