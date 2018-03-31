<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FinePayment.aspx.cs" Inherits="FinePayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://cdn.worldpay.com/v1/worldpay.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row justify-content-center">
    <div  id='paymentSection'></div>
    </div>
    <div class="row justify-content-center">
        <div class="payment-card-worldpay">
        
        <div>
            <asp:Label CssClass="payment-items-pos text-center" runat="server" ID="lblTotalAmount"></asp:Label>
            
        </div>
            <div>
            <asp:Button runat="server" CssClass="mt-4 payment-items-pos" OnClick="HandlerProcessPayment" Text="Process Payment"/>
        </div>
        </div>
    </div>
    <script type='text/javascript'>
        window.onload = function() {
            Worldpay.useTemplateForm({
                'clientKey': 'T_C_af06533a-a2a9-4c71-806b-b903ece511eb',
                'form':'paymentForm',
                'paymentSection':'paymentSection',
                'display':'inline',
                'reusable':false,
                'callback': function(obj) {
                    if (obj && obj.token) {
                        var _el = document.createElement('input');
                        _el.value = obj.token;
                        _el.type = 'hidden';
                        _el.name = 'token';
                        document.getElementById('paymentForm').appendChild(_el);
                        document.getElementById('paymentForm').submit();
                    }
                }
            });
        }
    </script>
 
</asp:Content>

