<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EbvLineReport.aspx.cs" Inherits="WebReport.EbvLineReport" %>

<%@ Register assembly="DevExpress.XtraCharts.v16.2.Web, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.XtraCharts.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
                <h2 >检查结果曲线图</h2>
        <table style="font-size: 16pt" >
            <tr>
                <th align="left">姓名:</th><td>xxx</td>
                <th>病理号</th><td>123456</td>
            </tr>
            <tr>
                <th th align="left">检查项目:</th><td colspan="2">EBV-DNA基因检测</td>
            </tr>
        </table>
    </div>
<hr style="height:1px;border:none;border-top:1px dashed lightgray;width: 80%" align="left"/>

    <div>

        <dx:WebChartControl ID="WebChartControl1" runat="server" CrosshairEnabled="True" Height="500px" Width="800px" DataSourceID="ObjectDataSource1" AppearanceNameSerializable="Gray" PaletteName="Office 2013">
            <DiagramSerializable>
                <dx:XYDiagram>
                    <AxisX VisibleInPanesSerializable="-1" Title-Text="检查日期" Title-Visibility="True">
                    </AxisX>
                    <AxisY VisibleInPanesSerializable="-1" Title-Text="结果值" Title-Visibility="True">
                    </AxisY>
                </dx:XYDiagram>
            </DiagramSerializable>
            <Legend Name="Default Legend"></Legend>
            <SeriesSerializable>
                <dx:Series Name="结果值(copy/mL)" ArgumentDataMember="TestDate" ColorDataMember="Result" ValueDataMembersSerializable="Result">
                    <ViewSerializable>
                        <dx:LineSeriesView>
                        </dx:LineSeriesView>
                    </ViewSerializable>
                </dx:Series>
            </SeriesSerializable>
            <SeriesTemplate ArgumentDataMember="TestDate" ValueDataMembersSerializable="Result">
            </SeriesTemplate>
        </dx:WebChartControl>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLineReportDemoItems" TypeName="WebReport.MonkData"></asp:ObjectDataSource>

    </div>
</form>
</body>
</html>