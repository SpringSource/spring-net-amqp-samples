#region License

/*
 * Copyright 2002-2009 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion


using System.Collections;
using Spring.RabbitQuickStart.Client.Gateways;
using Spring.RabbitQuickStart.Common.Data;

namespace Spring.RabbitQuickStart.Client.UI
{
    /// <summary>
    /// Handles requests from the UI and forwards them to the remote service.  Messages recieved from
    /// the service routed through this controller to update the UI. 
    /// </summary>
    /// <author>Mark Pollack</author>
    /// <author>Don McRae</author>
    public class StockController
    {
        private StockForm stockForm;

        private IStockServiceGateway stockService;
        
        public StockForm StockForm
        {
            get { return stockForm; }
            set { stockForm = value; }
        }

        public IStockServiceGateway StockService
        {
            get { return stockService; }
            set { stockService = value; }
        }

        public void SendTradeRequest()
        {
            TradeRequest tradeRequest = new TradeRequest();
            tradeRequest.AccountName = "ACCT-123";
            tradeRequest.BuyRequest = true;
            tradeRequest.OrderType = "MARKET";
            tradeRequest.Quantity = 314000000;
            tradeRequest.RequestId = "REQ-1";
            tradeRequest.Ticker = "CSCO";
            tradeRequest.UserName = "Joe Trader";
            
            stockService.Send(tradeRequest);
        }       
        
        public void UpdateMarketData(Quote quote)
        {
            stockForm.UpdateMarketData(quote);
        }

        public void UpdateTrade(TradeResponse tradeResponse)
        {
            stockForm.UpdateTrade(tradeResponse);
        }


    }
}