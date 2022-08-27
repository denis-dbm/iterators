using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Iterators.Tests;

public class JaggedArrayEnumerableTests
{
    readonly ITestOutputHelper _testOutputHelper;

    public JaggedArrayEnumerableTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Empty_enumerable_should_enumerate_nothing()
    {
        JaggedArrayEnumerable<int> enumerable = default;

        var enumerator = enumerable.GetEnumerator();

        enumerator.MoveNext().Should().BeFalse();
    }
    
    [Fact]
    public void Null_array_should_throw_ArgumentNullException()
    {
        Action action = TryNewEnumerable;
        action.Should().ThrowExactly<ArgumentNullException>();

        void TryNewEnumerable()
        {
            JaggedArrayEnumerable<int> enumerable = new(null);
        }
    }

    [Theory]
    [MemberData(nameof(GetSequenceAsJagged))]
    public void Arrays_should_be_enumerated_sequentially(int[][] array)
    {
        var enumerator = array.Flatten().GetEnumerator();
        int length = 0;

        while (enumerator.MoveNext())
            enumerator.Current.Should().Be(++length);

        length.Should().Be((int)array.CountElements());
    }
    
    [Theory]
    [MemberData(nameof(GetSequenceAsJagged))]
    public void Reset_should_resets_to_initial_position(int[][] array)
    {
        const int times = 7;
        var enumerator = array.Flatten().GetEnumerator();
        IList<int> beforeReset;
        IList<int> afterReset;
        
        Enumerate(ref enumerator, out beforeReset);
        enumerator.Reset();
        Enumerate(ref enumerator, out afterReset);

        afterReset.Should().BeEquivalentTo(beforeReset);
        
        static void Enumerate(ref JaggedArrayEnumerable<int>.Enumerator enumerator, out IList<int> output)
        {
            output = new List<int>();
            
            for (int i = 0; i < times; i++)
            {
                enumerator.MoveNext();
                output.Add(enumerator.Current);
            }
        }
    }

    [Theory]
    [MemberData(nameof(GetSequenceAsJagged))]
    public void Current_should_throw_InvalidOperationException_when_does_not_call_MoveNext(int[][] array)
    {
        Action action = TryUninitializedCurrent;

        action.Should().ThrowExactly<InvalidOperationException>();

        void TryUninitializedCurrent()
        {
            var enumerator = array.Flatten().GetEnumerator();
            _ = enumerator.Current;
        }
    }
    
    [Theory]
    [MemberData(nameof(GetSequenceAsJagged))]
    public void Current_should_throw_InvalidOperationException_after_all_iterations(int[][] array)
    {
        Action action = TryCurrentAfterIterations;

        action.Should().ThrowExactly<InvalidOperationException>();

        void TryCurrentAfterIterations()
        {
            var enumerator = array.Flatten().GetEnumerator();

            while (enumerator.MoveNext())
                _ = enumerator.Current;

            _ = enumerator.Current;
        }
    }

    public static IEnumerable<object[]> GetSequenceAsJagged()
    {
        yield return new object[]
        {
            new[]
            {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 6, 7, 8, 9, 10 },
                new[] { 11, 12, 13, 14, 15 },
                new[] { 16, 17, 18, 19, 20 }
            }
        };
    }
}