using System;

namespace Closure
{
    public struct FuncClosure
    {
        public static FuncClosure Create<T, TResult>(Func<T, TResult> action, T arg0)
        {
            return new FuncClosure
            {
                _delegate = action,
                _0 = Value.Pack(arg0)
            };
        }

        public static FuncClosure Create<T0, T1, TResult>(Func<T0, T1, TResult> action, T0 arg0, T1 arg1)
        {
            return new FuncClosure
            {
                _delegate = action,
                _0 = Value.Pack(arg0),
                _1 = Value.Pack(arg1)
            };
        }

        public static FuncClosure Create<T0, T1, T2, TResult>(Func<T0, T1, T2, TResult> action, T0 arg0, T1 arg1, T2 arg2)
        {
            return new FuncClosure
            {
                _delegate = action,
                _0 = Value.Pack(arg0),
                _1 = Value.Pack(arg1),
                _2 = Value.Pack(arg2)
            };
        }

        public static FuncClosure Create<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, TResult> action, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            return new FuncClosure
            {
                _delegate = action,
                _0 = Value.Pack(arg0),
                _1 = Value.Pack(arg1),
                _2 = Value.Pack(arg2),
                _3 = Value.Pack(arg3),
            };
        }

        public TResult Invoke<T, TResult>()
        {
            return (_delegate as Func<T, TResult>).Invoke(Value.UnPack<T>(_0));
        }

        public TResult Invoke<T0, T1, TResult>()
        {
            return (_delegate as Func<T0, T1, TResult>).Invoke(Value.UnPack<T0>(_0), Value.UnPack<T1>(_1));
        }

        public TResult Invoke<T0, T1, T2, TResult>()
        {
            return (_delegate as Func<T0, T1, T2, TResult>).Invoke(Value.UnPack<T0>(_0), Value.UnPack<T1>(_1), Value.UnPack<T2>(_2));
        }

        public TResult Invoke<T0, T1, T2, T3, TResult>()
        {
            return (_delegate as Func<T0, T1, T2, T3, TResult>).Invoke(Value.UnPack<T0>(_0), Value.UnPack<T1>(_1), Value.UnPack<T2>(_2), Value.UnPack<T3>(_3));
        }

        private Delegate _delegate;

        private Value _0;
        private Value _1;
        private Value _2;
        private Value _3;
    }
}
