﻿using NUnit.Framework;

namespace AutoDeconstruct.IntegrationTests;

public static class DeconstructExistsWithNoMatchTests
{
	[Test]
	public static void RunDeconstruct()
	{
		var data = "data";
		var id = Guid.NewGuid();
		var value = 3;

		var target = new DeconstructExistsWithNoMatch
		{
			Data = data,
			Id = id,
			Value = value
		};

		var (newData, newId, newValue) = target;

		Assert.Multiple(() =>
		{
			Assert.That(newData, Is.EqualTo(data));
			Assert.That(newId, Is.EqualTo(id));
			Assert.That(newValue, Is.EqualTo(value));
		});
	}
}

public sealed class DeconstructExistsWithNoMatch
{
	public string? Data { get; set; }
	public Guid Id { get; set; }
	public int Value { get; set; }

	public void Deconstruct(out Guid id, out int value) =>
		(id, value) = (this.Id, this.Value);
}