using System;

namespace RpcClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Title title = new Title();
            RpcClient_Test rpcClientTest = new RpcClient_Test();

            title.SetColor();
            Console.WriteLine("********RpcClientTest***********");
            Console.WriteLine();
            rpcClientTest.OpenWallet();
            rpcClientTest.InvokeBalanceOf();
            rpcClientTest.InvokeDestroyNormal1();
            rpcClientTest.InvokeDestroyNormal2();
            rpcClientTest.InvokeDestroyAbnormal();
            rpcClientTest.GetApplicationLog();
            rpcClientTest.GetBlock();
            rpcClientTest.GetContractState();
            rpcClientTest.GetNep5Transfers();
            rpcClientTest.GetPeers();
            rpcClientTest.ListPlugins();
            rpcClientTest.GetRawMempool1();
            rpcClientTest.GetRawMempool2();
            rpcClientTest.Sendfrom();
            rpcClientTest.GetUnclaimedGas();
            rpcClientTest.ValidateAddress();
            rpcClientTest.GetNextBlockValidators();
            rpcClientTest.GetVersion();
            rpcClientTest.WaitTransaction();
            rpcClientTest.TestBlockFromJson();

            Console.ReadLine();
        }
    }
}
