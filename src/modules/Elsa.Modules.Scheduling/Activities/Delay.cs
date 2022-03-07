﻿using System;
using Elsa.Attributes;
using Elsa.Contracts;
using Elsa.Models;

namespace Elsa.Modules.Scheduling.Activities;

public class Delay : Activity
{
    [Input] public Input<TimeSpan> TimeSpan { get; set; } = default!;

    protected override void Execute(ActivityExecutionContext context)
    {
        var timeSpan = context.ExpressionExecutionContext.Get(TimeSpan);
        var clock = context.ExpressionExecutionContext.GetRequiredService<ISystemClock>();
        var resumeAt = clock.UtcNow.Add(timeSpan);
        var payload = new DelayPayload(resumeAt);

        context.CreateBookmark(payload);
    }
}

public record DelayPayload(DateTime ResumeAt);