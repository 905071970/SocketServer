using MLZZF.SocketServer;

class Program
{
    static void Main(string[] args)
    {
        //����Tcp�����ʵ��
        TcpServer_MLZZF tcpServer = new TcpServer_MLZZF(IPAddress.Any, 60000, 0);
        //����Tcp����
        tcpServer.Start();

        //Ӧ��ͻ���
        tcpServer.onAccept += new TcpServer_MLZZF.args_1((id) =>
        {
            Console.WriteLine("�ͻ������ӽ���: id:" + id);
        });

        //�ͻ��˷�����Ϣ
        tcpServer.onReceive += new TcpServer_MLZZF.args_2((id, buff) =>
        {
            //��Ϣ����
            string str = Encoding.UTF8.GetString(buff);

            Console.WriteLine("���ճ��ȣ�" + buff.Length);
            Console.WriteLine("�ͻ���: id:" + id + " ��������Ϣ: " + str);
        });

        //�ͻ��˶Ͽ�����
        tcpServer.onExit += new TcpServer_MLZZF.args_1((id) =>
        {
            Console.WriteLine("�ͻ������ӶϿ�: id:" + id);
        });

        Console.ReadKey();
    }
}