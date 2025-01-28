namespace MyPathFinder.DataStructures
{
    public class HashTable<TValue>
    {
        private const int Max = 100;
        private readonly TValue[] _values = new TValue[Max]; 
        
        public TValue this[string key]
        {
            get => _values[Hash(key)];
            set => _values[Hash(key)] = value;
        }

        public static int Hash(string key)
        {
            var hash = 0;
            var c1 = 2;

            int[] funcTerms = new int[key.Length];
            funcTerms[0] = key[0];

            for (int i = 1; i < key.Length; i++)
            {
                while(true)
                { 
                    if (IsCoprimeWithEuclidAlgorithm(Max, c1))
                    {
                        funcTerms[i] = c1 * key[i];
                        c1 += c1;
                        break;
                    }

                    c1++;
                }
            }

            foreach (var t in funcTerms)
            {
                hash += t;
            }

            return hash % Max;
        }

        public static bool IsCoprimeWithEuclidAlgorithm(int M, int x = 2)
        {
            if(M <= 1 || x <= 0) 
                return false;

            if (x == 1)
                return true;

            return IsCoprimeWithEuclidAlgorithm(x, M % x);
        }
    }
}
