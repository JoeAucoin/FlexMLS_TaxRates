<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewFlexMLS_TaxRates.ascx.cs" Inherits="GIBS.Modules.FlexMLS_TaxRates.ViewFlexMLS_TaxRates" %>



<h1 style="text-align: center;"><asp:Label ID="lblH1Title" runat="server"></asp:Label></h1>

<div style="display: grid;justify-content: center;">

    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Town" HorizontalAlign="Center" 
            OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"  
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
            GridLines="None" 
            CssClass="table table-striped table-responsive">

        <Columns>


        <asp:TemplateField Headertext ="Tax Year" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
               <asp:Hyperlink runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TaxYear")%>' ID="HyperlinkTaxYear"/>   
            </ItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField Headertext="Town">
                <ItemTemplate>


               <asp:Hyperlink runat= "server" ID="Hyperlink2"/>   
                </ItemTemplate>
        </asp:TemplateField> 

        <asp:BoundField HeaderText="Tax Rate" DataField="TaxRate" ItemStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:c}"></asp:BoundField>

            </Columns>

        </asp:GridView>
    </div>
    <br clear="all" />
    <p>
    <asp:Repeater ID="RepeaterTowns" runat="server" OnItemDataBound="RepeaterTowns_OnItemDataBound" >
    <ItemTemplate>
    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink> | 
    </ItemTemplate>
    </asp:Repeater></p>

