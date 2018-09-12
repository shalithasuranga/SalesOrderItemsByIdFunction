using System;
using System.Collections.Generic;
using System.Text;
using RambaseCOSLib.Constants;
using RambaseCOSLib.Core.Data;
using RambaseCOSLib.Sales.Order;

namespace SalesOrderItemsByIdFunction.serverless
{
    class ServerlessFunction
    {
        public string Handle(string input) {
            DataTable ARG = new DataTable(1, "FILTER", "NO", "HANDLE", "OFFSET", "SORTBY");
            DataTable RES = new DataTable(1, "HANDLE", "POS", "SIZE");
            DataTable RTB = new DataTable(80, "DOCID", "ITM", "ST1", "IT", "PART", "TEXT", "MFRID", "REQ", "CONF", "QTY", "NETQTY", "CUR", "PRICE", "AMOUNT", "NETAMT", "YOURITM", "CUSPART");

            List<DataTable> tmpResult = SalesOrderItem.GetList();
            RTB.fillData(tmpResult[0]);
            RES.fillData(tmpResult[1]);

            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><SalesOrderItems>";
            for (int i = 0; i < RTB.getSize(); i++)
            {
                xml += $"<SalesOrderItem><SalesOrderItemId field=\"{ RTB.getValue(i, "ITM") }\" type=\"Integer\" descr=\"{COA1.ITM}\" /><Status field=\"{ RTB.getValue(i, "ST1") }\" type=\"Integer\" descr=\"{COA1.ST1}\" dov=\"COA.ST\" /><RequestedDeliveryDate field=\"{ RTB.getValue(i, "REQ") }\" type=\"Date\" descr=\"{CUSDOC1.REQ}\" /><ConfirmedDeliveryDate field=\"{ RTB.getValue(i, "CONF") }\" type=\"Date\" descr=\"{DOC1.CONF}\" /><CustomersReferenceNumber field=\"{ RTB.getValue(i, "YOURITM") }\" type=\"String\" descr=\"{CUSDOC1.YOURITM}\" /><CustomersProductName field=\"{ RTB.getValue(i, "CUSPART") }\" type=\"String\" descr=\"{CUSDOC1.CUSPART}\" /><ProductDescription field=\"{ RTB.getValue(i, "TEXT") }\" type=\"String\" descr=\"{DOC1.TEXT}\" /><Quantity field=\"{ RTB.getValue(i, "QTY") }\" type=\"Decimal\" descr=\"{COA1.QTY}\" /><RemainingQuantity field=\"{ RTB.getValue(i, "NETQTY") }\" type=\"Decimal\" descr=\"{CUSDOC1.NETQTY}\" /><Price><Currency field=\"{ RTB.getValue(i, "CUR") }\" type=\"String\" descr=\"{OBJECT.CURRENCY}\" /><GrossPrice field=\"{ RTB.getValue(i, "PRICE") }\" type=\"Decimal\" descr=\"{DOC1.PRICE}\" /></Price><Totals><Currency field=\"{ RTB.getValue(i, "CUR") }\" type=\"String\" descr=\"{OBJECT.CURRENCY}\" /><GrossAmount field=\"{ RTB.getValue(i, "AMOUNT") }\" type=\"Decimal\" descr=\"{DOC1.AMOUNT}\" /><NetAmount field=\"{ RTB.getValue(i, "NETAMT") }\" type=\"Decimal\" descr=\"{DOC1.NETAMT}\" /></Totals><Product><ProductId field=\"{ RTB.getValue(i, "IT") }\" type=\"It\" descr=\"{ART.IT}\" /><Name field=\"{ RTB.getValue(i, "PART") }\" type=\"String\" descr=\"{ART.PART}\" /><Manufacturer><ManufacturerId field=\"{ RTB.getValue(i, "MFRID") }\" type=\"Docref-no\" descr=\"{MFR.NO}\" /><ManufacturerLink field=\"{ RTB.getValue(i, "MFRID") }\" type=\"Docref-link\" descr=\"{MFR.DOC}\" /></Manufacturer><ProductLink field=\"ART/{ RTB.getValue(i, "IT") }\" type=\"Docref-link\" descr=\"{ART.DOC}\" /></Product><SalesOrderItemLink field=\"{ RTB.getValue(i, "DOCID") }\" type=\"Docref-itmlink\" descr=\"{COA1.DOCID}\" /></SalesOrderItem></SalesOrderItems>";
            }
            return xml;
        }
    }
}
