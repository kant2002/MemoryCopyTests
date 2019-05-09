# MemoryCopyTests

The goal of this benchmarks provide function which will cleanup all HTML tags from the string

## .NET Framework 4.7.2
```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
```

|                                Method |                       A |         Mean |       Error |      StdDev |
|-------------------------------------- |------------------------ |-------------:|------------:|------------:|
|                CharArrayPointerBuffer |                         |     15.07 ns |   0.3757 ns |   0.3331 ns |
| CharArrayPointerBufferWithStackAllock |                         |     22.12 ns |   0.5399 ns |   0.4508 ns |
|                CharArrayPointerBuffer | <div (...)/div> [18593] | 21,004.97 ns | 395.9096 ns | 370.3340 ns |
| CharArrayPointerBufferWithStackAllock | <div (...)/div> [18593] | 20,472.10 ns | 256.2283 ns | 227.1397 ns |
|                CharArrayPointerBuffer |   <foot(...)oter> [376] |    402.59 ns |   7.7258 ns |   7.5878 ns |
| CharArrayPointerBufferWithStackAllock |   <foot(...)oter> [376] |    384.92 ns |   7.1985 ns |   6.7335 ns |
|                CharArrayPointerBuffer |    small(...)tring [21] |     43.54 ns |   0.9537 ns |   1.6703 ns |
| CharArrayPointerBufferWithStackAllock |    small(...)tring [21] |     51.46 ns |   0.4759 ns |   0.4452 ns |

## .NET Core 2.2.2

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host]     : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT
```

|                                Method |                       A |         Mean |       Error |        StdDev |
|-------------------------------------- |------------------------ |-------------:|------------:|--------------:|
|                CharArrayPointerBuffer |                         |     17.08 ns |   0.4455 ns |     0.8033 ns |
| CharArrayPointerBufferWithStackAllock |                         |     23.24 ns |   0.5611 ns |     0.7680 ns |
|                                  Span |                         |     12.38 ns |   0.3520 ns |     0.3615 ns |
|                                 Span2 |                         |     12.20 ns |   0.3456 ns |     0.6232 ns |
|                CharArrayPointerBuffer | <div (...)/div> [18593] | 24,256.40 ns | 480.4840 ns | 1,113.5947 ns |
| CharArrayPointerBufferWithStackAllock | <div (...)/div> [18593] | 22,866.39 ns | 468.0550 ns | 1,273.3782 ns |
|                                  Span | <div (...)/div> [18593] | 18,896.73 ns | 376.6990 ns |   895.2650 ns |
|                                 Span2 | <div (...)/div> [18593] | 18,808.79 ns | 376.0150 ns |   809.4120 ns |
|                CharArrayPointerBuffer |   <foot(...)oter> [376] |    491.29 ns |   9.8867 ns |    20.1959 ns |
| CharArrayPointerBufferWithStackAllock |   <foot(...)oter> [376] |    416.23 ns |   8.3985 ns |    16.3807 ns |
|                                  Span |   <foot(...)oter> [376] |    431.45 ns |   8.7330 ns |    15.7473 ns |
|                                 Span2 |   <foot(...)oter> [376] |    441.00 ns |   9.5895 ns |    14.3531 ns |
|                CharArrayPointerBuffer |    small(...)tring [21] |     51.09 ns |   1.1290 ns |     2.0645 ns |
| CharArrayPointerBufferWithStackAllock |    small(...)tring [21] |     52.75 ns |   1.1500 ns |     2.4756 ns |
|                                  Span |    small(...)tring [21] |     25.58 ns |   0.5702 ns |     0.9044 ns |
|                                 Span2 |    small(...)tring [21] |     25.87 ns |   0.6235 ns |     0.6930 ns |

// * Warnings *
MultimodalDistribution
  Fast.Span: Default                                  -> It seems that the distribution can have several modes (mValue = 3.11)
  Fast.CharArrayPointerBufferWithStackAllock: Default -> It seems that the distribution is bimodal (mValue = 3.42)
  Fast.CharArrayPointerBufferWithStackAllock: Default -> It seems that the distribution can have several modes (mValue = 3.14)



## .NET Core 3.0.0-preview5-27626-15
```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host]     : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT
```

|                                Method |                       A |          Mean |       Error |      StdDev |
|-------------------------------------- |------------------------ |--------------:|------------:|------------:|
|                CharArrayPointerBuffer |                         |     17.112 ns |   0.4318 ns |   0.7094 ns |
| CharArrayPointerBufferWithStackAllock |                         |     11.673 ns |   0.3305 ns |   0.3674 ns |
|                                  Span |                         |      2.808 ns |   0.1074 ns |   0.1005 ns |
|                                 Span2 |                         |      2.213 ns |   0.1566 ns |   0.1465 ns |
|                                 Span3 |                         |      3.322 ns |   0.1639 ns |   0.2453 ns |
|                CharArrayPointerBuffer | <div (...)/div> [18593] | 26,287.959 ns | 275.7432 ns | 244.4392 ns |
| CharArrayPointerBufferWithStackAllock | <div (...)/div> [18593] | 20,270.300 ns | 370.6945 ns | 328.6110 ns |
|                                  Span | <div (...)/div> [18593] | 16,330.612 ns | 323.6889 ns | 474.4590 ns |
|                                 Span2 | <div (...)/div> [18593] | 16,133.109 ns | 272.0607 ns | 254.4858 ns |
|                                 Span3 | <div (...)/div> [18593] | 15,955.992 ns | 311.6672 ns | 306.0989 ns |
|                CharArrayPointerBuffer |   <foot(...)oter> [376] |    550.419 ns |  11.0909 ns |  12.7723 ns |
| CharArrayPointerBufferWithStackAllock |   <foot(...)oter> [376] |    403.129 ns |  16.5893 ns |  17.0359 ns |
|                                  Span |   <foot(...)oter> [376] |    374.680 ns |   6.4529 ns |   6.0360 ns |
|                                 Span2 |   <foot(...)oter> [376] |    384.612 ns |   5.8185 ns |   5.4426 ns |
|                                 Span3 |   <foot(...)oter> [376] |    369.795 ns |   7.0625 ns |   8.1331 ns |
|                CharArrayPointerBuffer |    small(...)tring [21] |     48.858 ns |   1.0508 ns |   1.3289 ns |
| CharArrayPointerBufferWithStackAllock |    small(...)tring [21] |     36.500 ns |   0.8240 ns |   1.1552 ns |
|                                  Span |    small(...)tring [21] |     14.064 ns |   0.2393 ns |   0.2238 ns |
|                                 Span2 |    small(...)tring [21] |     14.646 ns |   0.3802 ns |   0.3904 ns |
|                                 Span3 |    small(...)tring [21] |     29.956 ns |   0.6921 ns |   0.7405 ns |

// * Warnings *
MultimodalDistribution
  Fast.CharArrayPointerBuffer: Default -> It seems that the distribution can have several modes (mValue = 2.91)
  Fast.Span: Default                   -> It seems that the distribution can have several modes (mValue = 3.14)
  Fast.Span3: Default                  -> It seems that the distribution can have several modes (mValue = 3)
  Fast.Span: Default                   -> It seems that the distribution can have several modes (mValue = 2.82)