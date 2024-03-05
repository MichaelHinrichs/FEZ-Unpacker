//Written for FEZ. https://store.steampowered.com/app/224760/
internal class Program
{
    private static void Main(string[] args)
    {
        BinaryReader br = new BinaryReader(File.OpenRead(args[0]));

        int size = br.ReadInt32();
        for (int i = 0; i < size; i++)
        {
            string name = br.ReadString();
            Directory.CreateDirectory(Path.GetDirectoryName(args[0]) + "//" + Path.GetFileNameWithoutExtension(args[0]) + "//" + Path.GetDirectoryName(name));
            using FileStream FS = File.Create(Path.GetDirectoryName(args[0]) + "//" + Path.GetFileNameWithoutExtension(args[0]) + "//" + name);
            BinaryWriter bw = new(FS);
            bw.Write(br.ReadBytes(br.ReadInt32()));
            bw.Close();
        }
    }
}