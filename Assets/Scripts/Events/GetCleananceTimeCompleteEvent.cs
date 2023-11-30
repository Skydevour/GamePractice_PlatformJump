using System;

public class GetCleananceTimeCompleteEvent
{
    public readonly String ClearanceTime;

    public GetCleananceTimeCompleteEvent(String clearanceTime)
    {
        ClearanceTime = clearanceTime;
    }
}