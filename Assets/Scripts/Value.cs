using System;

namespace Closure
{
    struct Value
    {
        private static Value Ctor(bool _bool)
        {
            Value value = new Value();
            value._value = new __Value() { _bool = _bool };
            return value;
        }

        private static Value Ctor(int _int32)
        {
            Value value = new Value();
            value._value = new __Value() { _int32 = _int32 };
            return value;
        }

        private static Value Ctor(long _int64)
        {
            Value value = new Value();
            value._value = new __Value() { _int64 = _int64 };
            return value;
        }

        private static Value Ctor(float _single)
        {
            Value value = new Value();
            value._value = new __Value() { _single = _single };
            return value;
        }

        private static Value Ctor(double _double)
        {
            Value value = new Value();
            value._value = new __Value() { _double = _double };
            return value;
        }

        private static Value Ctor(string _string)
        {
            Value value = new Value();
            value._value = new __Value() { _string = _string };
            return value;
        }

        public static Value Pack<T>(T _value)
        {
            return Packer<T>._invoke(_value);
        }

        public static T UnPack<T>(Value _value)
        {
            return UnPacker<T>._invoke(_value);
        }

        static class Packer<T>
        {
            static Packer()
            {
                Packer<bool>._invoke = (v) => Value.Ctor(v);
                Packer<int>._invoke = (v) => Value.Ctor(v);
                Packer<long>._invoke = (v) => Value.Ctor(v);
                Packer<float>._invoke = (v) => Value.Ctor(v);
                Packer<double>._invoke = (v) => Value.Ctor(v);
                Packer<string>._invoke = (v) => Value.Ctor(v);
            }

            internal static Func<T, Value> _invoke = null;
        }

        static class UnPacker<T>
        {
            static UnPacker()
            {
                UnPacker<bool>._invoke = (v) => v._value._bool;
                UnPacker<int>._invoke = (v) => v._value._int32;
                UnPacker<long>._invoke = (v) => v._value._int64;
                UnPacker<float>._invoke = (v) => v._value._single;
                UnPacker<double>._invoke = (v) => v._value._double;
                UnPacker<string>._invoke = (v) => v._value._string;
            }

            internal static Func<Value, T> _invoke = null;
        }

        private __Value _value;
    }
}
