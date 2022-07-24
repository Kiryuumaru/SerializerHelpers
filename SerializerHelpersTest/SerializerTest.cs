using SerializerHelpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace SerializerTest;

public class PrimitiveType
{
    [Fact]
    public void BoolTest()
    {
        bool test1 = true;

        string? serTest1 = Serializer.Serialize(test1);
        bool desTest1 = Serializer.Deserialize<bool>(serTest1);

        Assert.Equal(test1, desTest1);

        bool? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        bool? desTest2 = Serializer.Deserialize<bool?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void ByteTest()
    {
        byte test1 = 64;

        string? serTest1 = Serializer.Serialize(test1);
        byte desTest1 = Serializer.Deserialize<byte>(serTest1);

        Assert.Equal(test1, desTest1);

        byte? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        byte? desTest2 = Serializer.Deserialize<byte?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void CharTest()
    {
        char test1 = 'b';

        string? serTest1 = Serializer.Serialize(test1);
        char desTest1 = Serializer.Deserialize<char>(serTest1);

        Assert.Equal(test1, desTest1);

        char? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        char? desTest2 = Serializer.Deserialize<char?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void DecimalTest()
    {
        decimal test1 = 112233445566778899.998877665544332211M;

        string? serTest1 = Serializer.Serialize(test1);
        decimal desTest1 = Serializer.Deserialize<decimal>(serTest1);

        Assert.Equal(test1, desTest1);

        decimal? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        decimal? desTest2 = Serializer.Deserialize<decimal?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void DoubleTest()
    {
        double test1 = 123456789.987654321;

        string? serTest1 = Serializer.Serialize(test1);
        double desTest1 = Serializer.Deserialize<double>(serTest1);

        Assert.Equal(test1, desTest1);

        double? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        double? desTest2 = Serializer.Deserialize<double?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void FloatTest()
    {
        float test1 = 12345.6789F;

        string? serTest1 = Serializer.Serialize(test1);
        float desTest1 = Serializer.Deserialize<float>(serTest1);

        Assert.Equal(test1, desTest1);

        float? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        float? desTest2 = Serializer.Deserialize<float?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void IntTest()
    {
        int test1 = 123456789;

        string? serTest1 = Serializer.Serialize(test1);
        int desTest1 = Serializer.Deserialize<int>(serTest1);

        Assert.Equal(test1, desTest1);

        int? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        int? desTest2 = Serializer.Deserialize<int?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void LongTest()
    {
        long test1 = 112233445566778899;

        string? serTest1 = Serializer.Serialize(test1);
        long desTest1 = Serializer.Deserialize<long>(serTest1);

        Assert.Equal(test1, desTest1);

        long? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        long? desTest2 = Serializer.Deserialize<long?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void SByteTest()
    {
        sbyte test1 = -64;

        string? serTest1 = Serializer.Serialize(test1);
        sbyte desTest1 = Serializer.Deserialize<sbyte>(serTest1);

        Assert.Equal(test1, desTest1);

        sbyte? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        sbyte? desTest2 = Serializer.Deserialize<sbyte?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void ShortTest()
    {
        short test1 = 12345;

        string? serTest1 = Serializer.Serialize(test1);
        short desTest1 = Serializer.Deserialize<short>(serTest1);

        Assert.Equal(test1, desTest1);

        short? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        short? desTest2 = Serializer.Deserialize<short?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void StringTest()
    {
        string test1 = "test_value";

        string? serTest1 = Serializer.Serialize(test1);
        string? desTest1 = Serializer.Deserialize<string>(serTest1);

        Assert.Equal(test1, desTest1);

        string? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        string? desTest2 = Serializer.Deserialize<string?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void UIntTest()
    {
        uint test1 = 123456789;

        string? serTest1 = Serializer.Serialize(test1);
        uint desTest1 = Serializer.Deserialize<uint>(serTest1);

        Assert.Equal(test1, desTest1);

        uint? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        uint? desTest2 = Serializer.Deserialize<uint?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void ULongTest()
    {
        ulong test1 = 112233445566778899;

        string? serTest1 = Serializer.Serialize(test1);
        ulong desTest1 = Serializer.Deserialize<ulong>(serTest1);

        Assert.Equal(test1, desTest1);

        ulong? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        ulong? desTest2 = Serializer.Deserialize<ulong?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void UShortTest()
    {
        ushort test1 = 12345;

        string? serTest1 = Serializer.Serialize(test1);
        ushort desTest1 = Serializer.Deserialize<ushort>(serTest1);

        Assert.Equal(test1, desTest1);

        ushort? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        ushort? desTest2 = Serializer.Deserialize<ushort?>(serTest2);

        Assert.Equal(test1, desTest2);
    }
}

public class AdditionalType
{
    [Fact]
    public void DateTimeTest()
    {
        DateTime test1 = DateTime.UtcNow;

        string? serTest1 = Serializer.Serialize(test1);
        DateTime desTest1 = Serializer.Deserialize<DateTime>(serTest1);

        Assert.Equal(test1, desTest1);

        DateTime? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        DateTime? desTest2 = Serializer.Deserialize<DateTime?>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void TimeSpanTest()
    {
        TimeSpan test1 = TimeSpan.FromDays(123);

        string? serTest1 = Serializer.Serialize(test1);
        TimeSpan desTest1 = Serializer.Deserialize<TimeSpan>(serTest1);

        Assert.Equal(test1, desTest1);

        TimeSpan? test2 = desTest1;

        string? serTest2 = Serializer.Serialize(test2);
        TimeSpan? desTest2 = Serializer.Deserialize<TimeSpan?>(serTest2);

        Assert.Equal(test1, desTest2);
    }
}

public class GenericType
{
    [Fact]
    public void DictionaryTest()
    {
        Dictionary<string, TimeSpan> test1 = new();
        test1.Add("1", TimeSpan.FromDays(1));
        test1.Add("2", TimeSpan.FromDays(2));
        test1.Add("3", TimeSpan.FromDays(3));

        string? serTest1 = Serializer.Serialize(test1);
        Dictionary<string, TimeSpan>? desTest1 = Serializer.Deserialize<Dictionary<string, TimeSpan>>(serTest1);

        Dictionary<string, double>? desTest2 = Serializer.Deserialize<Dictionary<string, double>>("");

        Assert.Equal(test1, desTest1);
        Assert.Empty(desTest2);
    }

    [Fact]
    public void KeyValuePairTest()
    {
        KeyValuePair<string, TimeSpan> test1 = new("1", TimeSpan.FromDays(1));

        string? serTest1 = Serializer.Serialize(test1);
        KeyValuePair<string, TimeSpan>? desTest1 = Serializer.Deserialize<KeyValuePair<string, TimeSpan>>(serTest1);

        Assert.Equal(test1, desTest1);

        KeyValuePair<string, TimeSpan>? test2 = test1;

        string? serTest2 = Serializer.Serialize(test2);
        KeyValuePair<string, TimeSpan>? desTest2 = Serializer.Deserialize<KeyValuePair<string, TimeSpan>>(serTest2);

        Assert.Equal(test1, desTest2);
    }

    [Fact]
    public void ListTest()
    {
        List<DateTime> test1 = new();
        test1.Add(DateTime.UtcNow - TimeSpan.FromDays(1));
        test1.Add(DateTime.UtcNow - TimeSpan.FromDays(2));
        test1.Add(DateTime.UtcNow - TimeSpan.FromDays(3));

        string? serTest1 = Serializer.Serialize(test1);
        List<DateTime>? desTest1 = Serializer.Deserialize<List<DateTime>>(serTest1);

        Assert.Equal(test1, desTest1);
    }
}

public class SpecialType
{
    [Fact]
    public void ArraySingleDimensionalTest()
    {
        TimeSpan[] test1 = new[]
        {
            TimeSpan.FromDays(1),
            TimeSpan.FromDays(2),
            TimeSpan.FromDays(3)
        };

        string? serTest1 = Serializer.Serialize(test1);
        TimeSpan[]? desTest1 = Serializer.Deserialize<TimeSpan[]>(serTest1);

        Assert.Equal(test1, desTest1);
    }

    [Fact]
    public void ArrayMultiDimensionalTest()
    {
        TimeSpan[,] test1 = new[,]
        {
            {
                TimeSpan.FromDays(1),
                TimeSpan.FromDays(2),
                TimeSpan.FromDays(3)
            },
            {
                TimeSpan.FromDays(4),
                TimeSpan.FromDays(5),
                TimeSpan.FromDays(6)
            }
        };

        string? serTest1 = Serializer.Serialize(test1);
        TimeSpan[,]? desTest1 = Serializer.Deserialize<TimeSpan[,]>(serTest1);

        Assert.Equal(test1, desTest1);

        TimeSpan[,,] test2 = new[,,]
        {
            {
                {
                    TimeSpan.FromDays(1),
                    TimeSpan.FromDays(2),
                    TimeSpan.FromDays(3)
                },
                {
                    TimeSpan.FromDays(4),
                    TimeSpan.FromDays(5),
                    TimeSpan.FromDays(6)
                }
            },
            {
                {
                    TimeSpan.FromDays(7),
                    TimeSpan.FromDays(8),
                    TimeSpan.FromDays(9)
                },
                {
                    TimeSpan.FromDays(10),
                    TimeSpan.FromDays(11),
                    TimeSpan.FromDays(12)
                }
            },
        };

        string? serTest2 = Serializer.Serialize(test2);
        TimeSpan[,,]? desTest2 = Serializer.Deserialize<TimeSpan[,,]>(serTest2);

        Assert.Equal(test2, desTest2);

        TimeSpan[,,,] test3 = new[,,,]
        {
            {
                {
                    {
                        TimeSpan.FromDays(1),
                        TimeSpan.FromDays(2),
                        TimeSpan.FromDays(3)
                    },
                    {
                        TimeSpan.FromDays(4),
                        TimeSpan.FromDays(5),
                        TimeSpan.FromDays(6)
                    }
                },
                {
                    {
                        TimeSpan.FromDays(7),
                        TimeSpan.FromDays(8),
                        TimeSpan.FromDays(9)
                    },
                    {
                        TimeSpan.FromDays(10),
                        TimeSpan.FromDays(11),
                        TimeSpan.FromDays(12)
                    }
                },
            },
            {
                {
                    {
                        TimeSpan.FromDays(1),
                        TimeSpan.FromDays(2),
                        TimeSpan.FromDays(3)
                    },
                    {
                        TimeSpan.FromDays(4),
                        TimeSpan.FromDays(5),
                        TimeSpan.FromDays(6)
                    }
                },
                {
                    {
                        TimeSpan.FromDays(7),
                        TimeSpan.FromDays(8),
                        TimeSpan.FromDays(9)
                    },
                    {
                        TimeSpan.FromDays(10),
                        TimeSpan.FromDays(11),
                        TimeSpan.FromDays(12)
                    }
                },
            },
        };

        string? serTest3 = Serializer.Serialize(test3);
        TimeSpan[,,,]? desTest3 = Serializer.Deserialize<TimeSpan[,,,]>(serTest3);

        Assert.Equal(test3, desTest3);
    }

    [Fact]
    public void ArrayJaggedTest()
    {
        TimeSpan[][] test1 = new TimeSpan[][]
        {
            new TimeSpan[]
            {
                TimeSpan.FromDays(1),
                TimeSpan.FromDays(2),
                TimeSpan.FromDays(3)
            },
            new TimeSpan[]
            {
                TimeSpan.FromDays(4),
                TimeSpan.FromDays(5),
                TimeSpan.FromDays(6)
            }
        };

        string? serTest1 = Serializer.Serialize(test1);
        TimeSpan[][]? desTest1 = Serializer.Deserialize<TimeSpan[][]>(serTest1);

        Assert.Equal(test1, desTest1);

        TimeSpan[][][] test2 = new TimeSpan[][][]
        {
            new TimeSpan[][]
            {
                new TimeSpan[]
                {
                    TimeSpan.FromDays(1),
                    TimeSpan.FromDays(2),
                    TimeSpan.FromDays(3)
                },
                new TimeSpan[]
                {
                    TimeSpan.FromDays(4),
                    TimeSpan.FromDays(5),
                    TimeSpan.FromDays(6)
                }
            },
            new TimeSpan[][]
            {
                new TimeSpan[]
                {
                    TimeSpan.FromDays(7),
                    TimeSpan.FromDays(8),
                    TimeSpan.FromDays(9)
                },
                new TimeSpan[]
                {
                    TimeSpan.FromDays(10),
                    TimeSpan.FromDays(11),
                    TimeSpan.FromDays(12)
                }
            }
        };

        string? serTest2 = Serializer.Serialize(test2);
        TimeSpan[][][]? desTest2 = Serializer.Deserialize<TimeSpan[][][]>(serTest2);

        Assert.Equal(test2, desTest2);
    }

    [Fact]
    public void ArrayMixedTest()
    {
        TimeSpan[][,] test1 = new TimeSpan[][,]
        {
            new TimeSpan[,]
            {
                {
                    TimeSpan.FromDays(1),
                    TimeSpan.FromDays(2),
                    TimeSpan.FromDays(3)
                },
                {
                    TimeSpan.FromDays(4),
                    TimeSpan.FromDays(5),
                    TimeSpan.FromDays(6)
                }
            },
            new TimeSpan[,]
            {
                {
                    TimeSpan.FromDays(7),
                    TimeSpan.FromDays(8),
                    TimeSpan.FromDays(9)
                },
                {
                    TimeSpan.FromDays(10),
                    TimeSpan.FromDays(11),
                    TimeSpan.FromDays(12)
                }
            }
        };

        string? serTest1 = Serializer.Serialize(test1);
        TimeSpan[][,]? desTest1 = Serializer.Deserialize<TimeSpan[][,]>(serTest1);

        Assert.Equal(test1, desTest1);

        TimeSpan[,][] test2 = new TimeSpan[,][]
        {
            {
                new TimeSpan[]
                {
                    TimeSpan.FromDays(1),
                    TimeSpan.FromDays(2),
                    TimeSpan.FromDays(3)
                },
                new TimeSpan[]
                {
                    TimeSpan.FromDays(4),
                    TimeSpan.FromDays(5),
                    TimeSpan.FromDays(6)
                }
            },
            {
                new TimeSpan[]
                {
                    TimeSpan.FromDays(7),
                    TimeSpan.FromDays(8),
                    TimeSpan.FromDays(9)
                },
                new TimeSpan[]
                {
                    TimeSpan.FromDays(10),
                    TimeSpan.FromDays(11),
                    TimeSpan.FromDays(12)
                }
            },
        };

        string? serTest2 = Serializer.Serialize(test2);
        TimeSpan[,][]? desTest2 = Serializer.Deserialize<TimeSpan[,][]>(serTest2);

        Assert.Equal(test2, desTest2);
    }
}
