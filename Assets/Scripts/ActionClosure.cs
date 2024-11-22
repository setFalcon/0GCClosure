using System;

namespace Closure
{
    struct ActionClosure
    {
        public static ActionClosure Create<T>(Action<T> action, T arg0)
        {
            return new ActionClosure
            {
                _delegate = action,
                _0 = Value.Pack(arg0)
            };
        }

        public static ActionClosure Create<T0, T1>(Action<T0, T1> action, T0 arg0, T1 arg1)
        {
            return new ActionClosure
            {
                _delegate = action,
                _0 = Value.Pack(arg0),
                _1 = Value.Pack(arg1)
            };
        }

        public static ActionClosure Create<T0, T1, T2>(Action<T0, T1, T2> action, T0 arg0, T1 arg1, T2 arg2)
        {
            return new ActionClosure
            {
                _delegate = action,
                _0 = Value.Pack(arg0),
                _1 = Value.Pack(arg1),
                _2 = Value.Pack(arg2)
            };
        }

        public static ActionClosure Create<T0, T1, T2, T3>(Action<T0, T1, T2, T3> action, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            return new ActionClosure
            {
                _delegate = action,
                _0 = Value.Pack(arg0),
                _1 = Value.Pack(arg1),
                _2 = Value.Pack(arg2),
                _3 = Value.Pack(arg3),
            };
        }

        public void Invoke<T>()
        {
            (_delegate as Action<T>).Invoke(Value.UnPack<T>(_0));
        }

        public void Invoke<T0, T1>()
        {
            (_delegate as Action<T0, T1>).Invoke(Value.UnPack<T0>(_0), Value.UnPack<T1>(_1));
        }

        public void Invoke<T0, T1, T2>()
        {
            (_delegate as Action<T0, T1, T2>).Invoke(Value.UnPack<T0>(_0), Value.UnPack<T1>(_1), Value.UnPack<T2>(_2));
        }

        public void Invoke<T0, T1, T2, T3>()
        {
            (_delegate as Action<T0, T1, T2, T3>).Invoke(Value.UnPack<T0>(_0), Value.UnPack<T1>(_1), Value.UnPack<T2>(_2), Value.UnPack<T3>(_3));
        }

        private Delegate _delegate;

        private Value _0;
        private Value _1;
        private Value _2;
        private Value _3;
    }
}
