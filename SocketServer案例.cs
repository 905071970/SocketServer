using MLZZF.SocketServer;

class Program
{
    static void Main(string[] args)
    {
        //创建Tcp服务端实列
        TcpServer_MLZZF tcpServer = new TcpServer_MLZZF(IPAddress.Any, 60000, 0);
        //启动Tcp服务
        tcpServer.Start();

        //应答客户端
        tcpServer.onAccept += new TcpServer_MLZZF.args_1((id) =>
        {
            Console.WriteLine("客户端连接进入: id:" + id);
        });

        //客户端发来消息
        tcpServer.onReceive += new TcpServer_MLZZF.args_2((id, buff) =>
        {
            //消息解析
            string str = Encoding.UTF8.GetString(buff);

            Console.WriteLine("接收长度：" + buff.Length);
            Console.WriteLine("客户端: id:" + id + " 发来的消息: " + str);
        });

        //客户端断开连接
        tcpServer.onExit += new TcpServer_MLZZF.args_1((id) =>
        {
            Console.WriteLine("客户端连接断开: id:" + id);
        });

        Console.ReadKey();
    }
}