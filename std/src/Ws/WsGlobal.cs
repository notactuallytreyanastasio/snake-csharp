using S = System;
using T = System.Threading.Tasks;
namespace TemperLang.Std.Ws
{
    public static class WsGlobal
    {
        public static T::Task<IWsServer> WsListen(int port__6)
        {
            throw new S::Exception();
        }
        public static T::Task<IWsConnection> WsAccept(IWsServer server__8)
        {
            throw new S::Exception();
        }
        public static T::Task<IWsConnection> WsConnect(string url__10)
        {
            throw new S::Exception();
        }
        public static T::Task<S::Tuple<object ?>> WsSend(IWsConnection conn__12, string msg__13)
        {
            throw new S::Exception();
        }
        public static T::Task<string ?> WsRecv(IWsConnection conn__15)
        {
            throw new S::Exception();
        }
        public static T::Task<S::Tuple<object ?>> WsClose(IWsConnection conn__17)
        {
            throw new S::Exception();
        }
    }
}
