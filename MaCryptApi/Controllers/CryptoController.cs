using AccountStore;
using AccountStore.AccountCollection;
using MaCryptApi.Clients;
using MaCryptApi.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaCryptApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly CoinLibClient _cryptoViewClient;
        private readonly BlockchainClient _blockchainClient;
        private readonly AccountServices _accountServices;

        public CryptoController(CoinLibClient cryptoViewClient, BlockchainClient blockchainClient, AccountServices accountServices)
        {
            _cryptoViewClient = cryptoViewClient;
            _blockchainClient = blockchainClient;
            _accountServices = accountServices;
        }

        //get метод, который возвращает данные про указанную криптовалюту
        [HttpGet("info")]
        public async Task<CryptoBySymbol> GetCryptoBySymbol([FromQuery] Parameters.OneCryptoParameter parameters)
        {

            var cryptoInfo = await _cryptoViewClient.GetCryptoBySymbol(parameters.Symbol, parameters.Pref);

            cryptoInfo.markets.RemoveRange(1, 2);

            return cryptoInfo;
        }

        //get метод, который возвращает топ10 криптовалют за указаным параметром
        [HttpGet("list")]
        public async Task<CryptoList> GetCryptoList([FromQuery] Parameters.CryptoListParameter parameters)
        {
            var cryptoList = await _cryptoViewClient.GetCryptoList(parameters.Pref, parameters.Order);

            cryptoList.coins.RemoveRange(10, 90);

            return cryptoList;
        }

        //get метод, который возвращает данные про кошелёк
        [HttpGet("wallet")]
        public async Task<Responses> GetWalletInfo([FromQuery] Parameters.WalletParameter parameters)
        {
            var walletInfo = await _blockchainClient.GetWalletInfo(parameters.Adress);

            var result = new Responses
            {
                AddressOfOwner = walletInfo.address,
                NumOfTransactions = walletInfo.n_tx,
                TotalReceived = Convert.ToString(walletInfo.total_received / 100000000.00),
                TotalSent = Convert.ToString(walletInfo.total_sent / 100000000),
                CurrentBalance = Convert.ToString(walletInfo.final_balance / 100000000),
            };

            result.Transactions = new List<Responses.Transaction>();

            foreach (Tx trans in walletInfo.txs)
            {
                Responses.Transaction transaction = new Responses.Transaction
                {
                    Hash = trans.hash,
                    Fee = trans.fee,
                    Time = trans.time,
                    ResultOfTransaction = trans.result,
                    BalanceAfter = trans.balance,
                };
                result.Transactions.Add(transaction);
            }

            return result;
        }

        //Запросы на создание, изменение, удаление и просмотр аккаунта
        [HttpGet("account/{id}")]
        public async Task<Account> GetAccount(string id)
        
        {
            return await _accountServices.GetAccount(id);
        }

        [HttpPost("create")]
        public void AddAccount(Account account)
        {
            _ = _accountServices.AddAccount(account);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteAccount(string id)
        {
            _ = _accountServices.DeleteAccount(id);
        }

        [HttpPut("update")]
        public void UpdateAccount(Account account)
        {
            _ = _accountServices.UpdateAccount(account);
        }

    }
}