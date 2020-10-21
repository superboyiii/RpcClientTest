using Neo;
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.Network.RPC.Models;
using System;
using Utility = Neo.Network.RPC.Utility;

namespace RpcClientTest
{
    class RpcClient_Test
    {
        private readonly RpcClient rpcClient = new RpcClient("http://localhost:12332");

        /*open wallet*/
        public void OpenWallet()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Open Wallet");
            var openwallet = rpcClient.OpenWalletAsync("admin.json", "1");
            string openwalletresult = openwallet.Result.ToString();
            Console.WriteLine("result: " + openwalletresult);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*invoke balanceof*/
        public void InvokeBalanceOf()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Invoke Balanceof");
            string openwalletresult = rpcClient.OpenWalletAsync("admin.json", "1").Result.ToString();
            Console.WriteLine("open wallet: " + openwalletresult);
            RpcStack rpcStack = new RpcStack()
            {
                Type = "Hash160",
                Value = "0xf642a0401fdd56a03114639a98b7963eb587a30a"
            };
            Signer[] signers = new[]
            {
                new Signer
                {
                    Account = UInt160.Parse("0x9f2dd7df630980dce111d3b31ebe35d3cfae58cd"),
                    Scopes = WitnessScope.CalledByEntry
                }
            };
            var rpcInvokeResult = rpcClient.InvokeFunctionAsync("0x254b9decd76080ef368e7a6b0a065938dfbc31cf", "balanceOf", new RpcStack[] { rpcStack }, signers);
            var balanceOf = rpcInvokeResult.Result.ToJson();
            Console.WriteLine("result: " + balanceOf);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*invoke destory(single signer)*/
        public void InvokeDestroyNormal1()
        {
            
            Console.WriteLine("********************************");
            Console.WriteLine("Destroy(normal- > single signer)");
            RpcStack[] emptyRpcStack = new RpcStack[] { };
            Signer[] signers = new[]
                {
                    new Signer
                    {
                        Account = UInt160.Parse("0xf642a0401fdd56a03114639a98b7963eb587a30a"),
                        Scopes = WitnessScope.CalledByEntry
                    }
                };
            var rpcInvokeResult = rpcClient.InvokeFunctionAsync("0x254b9decd76080ef368e7a6b0a065938dfbc31cf", "destroy", emptyRpcStack, signers);
            var destroy = rpcInvokeResult.Result.ToJson();
            Console.WriteLine("result: " + destroy);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*invoke destory(normal2)*/
        public void InvokeDestroyNormal2()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Destroy(normal -> multi signers)");
            RpcStack[] emptyRpcStack = new RpcStack[] { };
            Signer[] signers = new[]
                {
                    new Signer
                    {
                        Account = UInt160.Parse("0xf642a0401fdd56a03114639a98b7963eb587a30a"),
                        Scopes = WitnessScope.CalledByEntry
                    },
                    new Signer
                    {
                        Account = UInt160.Parse("0x9f2dd7df630980dce111d3b31ebe35d3cfae58cd"),
                        Scopes = WitnessScope.CalledByEntry
                    }
                };
            var rpcInvokeResult = rpcClient.InvokeFunctionAsync("0x254b9decd76080ef368e7a6b0a065938dfbc31cf", "destroy", emptyRpcStack, signers);
            var destroy = rpcInvokeResult.Result.ToJson();
            Console.WriteLine("result: " + destroy);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*invoke destory(exeception case)*/
        public void InvokeDestroyAbnormal()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Destroy(exeception -> signer is not owner)");
            RpcStack[] emptyRpcStack = new RpcStack[] { };
            Signer[] signers = new[]
                {
                    new Signer
                    {
                        Account = UInt160.Parse("0x9f2dd7df630980dce111d3b31ebe35d3cfae58cd"),
                        Scopes = WitnessScope.CalledByEntry
                    }
                };
            var rpcInvokeResult = rpcClient.InvokeFunctionAsync("0x254b9decd76080ef368e7a6b0a065938dfbc31cf", "destroy", emptyRpcStack, signers);
            var destroy = rpcInvokeResult.Result.ToJson();
            Console.WriteLine("result: " + destroy);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetApplicationLog*/
        public void GetApplicationLog()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetApplicationLog");
            var getApplicationLog = rpcClient.GetApplicationLogAsync("0xee80fefe70d9d1fa091816797ea003d5793c72f35bb8960a2ce9e591905a0f71").Result.ToJson();
            Console.WriteLine("result: " + getApplicationLog);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetBlock*/
        public void GetBlock()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetBlock");
            var getblock = rpcClient.GetBlockAsync("2000").Result.ToJson();
            Console.WriteLine("result: " + getblock);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetContractState*/
        public void GetContractState()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetContractState");
            var getContractState = rpcClient.GetContractStateAsync("0x254b9decd76080ef368e7a6b0a065938dfbc31cf").Result.ToJson();
            Console.WriteLine("result: " + getContractState);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetNep5Transfers*/
        public void GetNep5Transfers()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetNep5Transfers");
            var getNep5Transfers = rpcClient.GetNep5TransfersAsync("NedjwsfAJYFas9rn8UHWQftTW4oKAQyW9h", 0).Result.ToJson();
            Console.WriteLine("result: " + getNep5Transfers);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetPeers*/
        public void GetPeers()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetPeers");
            var getPeers = rpcClient.GetPeersAsync().Result.ToJson();
            Console.WriteLine("result: " + getPeers);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*ListPlugins*/
        public void ListPlugins()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("ListPlugins");
            var listPlugins = rpcClient.ListPluginsAsync().Result;
            Console.WriteLine("result: ");
            foreach (var plugin in listPlugins)
            {
                Console.WriteLine(plugin.ToJson());
            }
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetRawMempool1*/
        public void GetRawMempool1()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetRawMempool");
            var getRawMempool = rpcClient.GetRawMempoolAsync().Result;
            foreach (var tx in getRawMempool)
            {
                Console.WriteLine("tx: " + tx);
            }
            Console.WriteLine("result: ");
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetRawMempool2*/
        public void GetRawMempool2()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetRawMempool");
            var getRawMempool = rpcClient.GetRawMempoolBothAsync().Result.ToJson();
            Console.WriteLine("result: " + getRawMempool);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*Sendfrom*/
        public void Sendfrom()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Sendfrom");
            var sendFromResult = rpcClient.SendFromAsync("0x254b9decd76080ef368e7a6b0a065938dfbc31cf", "NLtDqwnj9s7wQVyaiD5ohjV3e9fUVkZxDp", "NedjwsfAJYFas9rn8UHWQftTW4oKAQyW9h", "2").Result.ToString();
            Console.WriteLine("result: " + sendFromResult);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetUnclaimedGas*/
        public void GetUnclaimedGas()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetUnclaimedGas");
            var getUnclaimedGas = rpcClient.GetUnclaimedGasAsync("NLtDqwnj9s7wQVyaiD5ohjV3e9fUVkZxDp").Result.ToJson();
            Console.WriteLine("result: " + getUnclaimedGas);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*ValidateAddress*/
        public void ValidateAddress()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("ValidateAddress");
            var validateAddress = rpcClient.ValidateAddressAsync("NLtDqwnj9s7wQVyaiD5ohjV3e9fUVkZxDp").Result.ToJson();
            Console.WriteLine("result: " + validateAddress);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetNextBlockValidators*/
        public void GetNextBlockValidators()
        {
            int i = 1;
            Console.WriteLine("********************************");
            Console.WriteLine("GetNextBlockValidators");
            var getNextBlockValidators = rpcClient.GetNextBlockValidatorsAsync().Result;
            foreach (var validator in getNextBlockValidators)
            {
                Console.Write("validator" + i.ToString() + ": ");
                Console.WriteLine(validator.ToJson());
                i++;
                
            }
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*GetVersion*/
        public void GetVersion()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetVersion");
            var getVersion = rpcClient.GetVersionAsync().Result.ToJson();
            Console.WriteLine("result: " + getVersion);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*WaitTransaction*/
        public void WaitTransaction()
        {
            WalletAPI walletAPI = new WalletAPI(rpcClient);
            Console.WriteLine("********************************");
            Console.WriteLine("WaitTransaction");
            var sendFromResult = rpcClient.SendFromAsync("0x254b9decd76080ef368e7a6b0a065938dfbc31cf", "NLtDqwnj9s7wQVyaiD5ohjV3e9fUVkZxDp", "NedjwsfAJYFas9rn8UHWQftTW4oKAQyW9h", "2").Result;
            Console.WriteLine("send: " + sendFromResult.ToString());
            Transaction tx = Utility.TransactionFromJson(sendFromResult);
            var waitTx = walletAPI.WaitTransactionAsync(tx).Result.ToJson();
            Console.WriteLine();
            Console.WriteLine("confirmed: " + waitTx);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        /*TestBlockFromJson*/
        public void TestBlockFromJson()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("BlockFromJson");
            var getBlock = rpcClient.GetBlockAsync("2000").Result.ToJson();
            var block = Utility.BlockFromJson(getBlock).ToJson();
            Console.WriteLine("result: " + block);
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

    }
}
