using System.Diagnostics;

namespace _1._18BinaryBalanceTree
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Weight { get; set; }
    }

    public class Program
    {
        static Random rnd = new Random();
        static long total;
        public static void CreateRandomTree(TreeNode node, int level)
        {
            node.Right = new TreeNode();
            node.Left = new TreeNode();
            node.Weight = rnd.Next(100);
            total += node.Weight;
            level--;
            if (level == 0)
            {
                node.Left.Weight = rnd.Next(100);
                node.Right.Weight = rnd.Next(100);
                total += node.Left.Weight;
                total += node.Right.Weight;
                return;
            }

            CreateRandomTree(node.Left, level);
            CreateRandomTree(node.Right, level);
        }

        public static long WeightTree(TreeNode root)
        {
            return
                (long)root.Weight +
                (root.Left != null ? WeightTree(root.Left) : 0) +
                (root.Right != null ? WeightTree(root.Right) : 0);

        }

        public static async Task<long> WeightTreeMT(TreeNode root, int lvl = 4)
        {
            if (lvl <= 0)
                return WeightTree(root);
            int nextLvl = lvl - 1;
            return
                (long)root.Weight +
                (root.Left  != null ? await WeightTreeMT(root.Left, nextLvl)  : 0) +
                (root.Right != null ? await WeightTreeMT(root.Right, nextLvl) : 0);

        }

        static void Main(string[] args)
        {
            int treeLevel = 25;

            Console.WriteLine($"Starting tree creation with depth {treeLevel}...");
            TreeNode root = new TreeNode();
            CreateRandomTree(root, treeLevel);
            Console.WriteLine($"Tree created with total weight: {total}");

            Stopwatch swSingle = new Stopwatch();
            swSingle.Start();
            long resultSingle = WeightTree(root);
            swSingle.Stop();
            Console.WriteLine($"Single weight: {resultSingle}; Time: {swSingle.ElapsedMilliseconds}");

            ThreadPool.SetMinThreads(32, 32);
            ThreadPool.SetMaxThreads(64, 64);


            Stopwatch sw = new Stopwatch();
            sw.Start();
            long resultMulti = WeightTreeMT(root).Result;
            sw.Stop();
            Console.WriteLine($"Multi weight: {resultMulti}; Time: {sw.ElapsedMilliseconds}");

        }
    }
}