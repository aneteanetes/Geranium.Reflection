using System;

namespace Geranium.Reflection.Struct
{
    public static class InternalHasher
    {
        public static int Hash(Type type, object value)
        {
            return type.GetHashCode() ^ value.GetHashCode();
        }

        public static int Hash(Type type1, Type type2, object value)
        {
            var _hashCode = type1.GetHashCode();
            _hashCode = HashInternal(_hashCode, type2.GetHashCode());
            _hashCode = HashInternal(_hashCode, value.GetHashCode());

            return _hashCode;
        }

        public static int Hash(Type type, object[] args)
        {
            var _hashCode= type.GetHashCode();
            switch (args.Length)
            {
                case 0: break;
                case 1:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    break;

                case 2:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    break;

                case 3:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    break;

                case 4:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    break;

                case 5:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    break;

                case 6:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    break;

                case 7:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    break;

                case 8:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    break;

                case 9:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[8].GetType().GetHashCode());
                    break;

                case 10:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[8].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[9].GetType().GetHashCode());
                    break;

                case 11:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[8].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[9].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[10].GetType().GetHashCode());
                    break;

                case 12:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[8].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[9].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[10].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[11].GetType().GetHashCode());
                    break;

                case 13:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[8].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[9].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[10].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[11].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[12].GetType().GetHashCode());
                    break;

                case 14:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[8].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[9].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[10].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[11].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[12].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[13].GetType().GetHashCode());
                    break;

                case 15:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[8].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[9].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[10].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[11].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[12].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[13].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[14].GetType().GetHashCode());
                    break;

                case 16:
                    _hashCode = HashInternal(_hashCode,args[0].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[1].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[2].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[3].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[4].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[5].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[6].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[7].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[8].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[9].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[10].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[11].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[12].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[13].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[14].GetType().GetHashCode());
                    _hashCode = HashInternal(_hashCode,args[15].GetType().GetHashCode());
                    break;

                default: throw new InsaneException();
            }
            return _hashCode;
        }

        private static int HashInternal(int current, int hash) => (current* 397) ^ hash;
    }
}
