﻿#if NET45PLUS

using System.Runtime.CompilerServices;
using System.Threading;

[assembly: TypeForwardedTo(typeof(Volatile))]

#else

#define FEATURE_CORECLR

// ==++==
// 
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// 
// ==--==
//
// <OWNER>[....]</OWNER>
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Runtime.CompilerServices;
using System.Runtime;
using System.Security;

#if !PORTABLE
using System.Runtime.ConstrainedExecution;
#endif

namespace System.Threading
{
    //
    // Methods for accessing memory with volatile semantics.  These are preferred over Thread.VolatileRead
    // and Thread.VolatileWrite, as these are implemented more efficiently.
    //
    // (We cannot change the implementations of Thread.VolatileRead/VolatileWrite without breaking code
    // that relies on their overly-strong ordering guarantees.)
    //
    // The actual implementations of these methods are typically supplied by the VM at JIT-time, because C# does
    // not allow us to express a volatile read/write from/to a byref arg.
    // See getILIntrinsicImplementationForVolatile() in jitinterface.cpp.
    //
    public static class Volatile
    {
#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static bool Read(ref bool location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        public static sbyte Read(ref sbyte location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static byte Read(ref byte location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static short Read(ref short location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        public static ushort Read(ref ushort location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static int Read(ref int location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        public static uint Read(ref uint location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static long Read(ref long location)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile read
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            return Interlocked.CompareExchange(ref location, 0, 0);
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        [SecuritySafeCritical] // contains unsafe code
        public static ulong Read(ref ulong location)
        {
            unsafe
            {
                //
                // There is no overload of Interlocked.Exchange that accepts a ulong.  So we have
                // to do some pointer tricks to pass our arguments to the overload that takes a long.
                //
                fixed (ulong* pLocation = &location)
                {
                    return (ulong)Interlocked.CompareExchange(ref *(long*)pLocation, 0, 0);
                }
            }
        }
#endif

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static IntPtr Read(ref IntPtr location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        public static UIntPtr Read(ref UIntPtr location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static float Read(ref float location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static double Read(ref double location)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile read
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            return Interlocked.CompareExchange(ref location, 0, 0);
        }
#endif

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [SecuritySafeCritical] //the intrinsic implementation of this method contains unverifiable code
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static T Read<T>(ref T location) where T : class
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }




#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write(ref bool location, bool value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        public static void Write(ref sbyte location, sbyte value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write(ref byte location, byte value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write(ref short location, short value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        public static void Write(ref ushort location, ushort value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write(ref int location, int value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        public static void Write(ref uint location, uint value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write(ref long location, long value)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile write 
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            Interlocked.Exchange(ref location, value);
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        [SecuritySafeCritical] // contains unsafe code
        public static void Write(ref ulong location, ulong value)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile write 
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            unsafe
            {
                //
                // There is no overload of Interlocked.Exchange that accepts a ulong.  So we have
                // to do some pointer tricks to pass our arguments to the overload that takes a long.
                //
                fixed (ulong* pLocation = &location)
                {
                    Interlocked.Exchange(ref *(long*)pLocation, (long)value);
                }
            }
        }
#endif

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write(ref IntPtr location, IntPtr value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        [CLSCompliant(false)]
        public static void Write(ref UIntPtr location, UIntPtr value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write(ref float location, float value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write(ref double location, double value)
        {
            //
            // On 32-bit machines, we use this implementation, since an ordinary volatile write 
            // would not be atomic.
            //
            // On 64-bit machines, the VM will replace this with a more efficient implementation.
            //
            Interlocked.Exchange(ref location, value);
        }
#endif

#if !PORTABLE
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [SecuritySafeCritical] //the intrinsic implementation of this method contains unverifiable code
#if !FEATURE_CORECLR
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
        public static void Write<T>(ref T location, T value) where T : class
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }
    }
}

#endif
