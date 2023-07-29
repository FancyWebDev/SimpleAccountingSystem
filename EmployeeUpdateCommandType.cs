namespace SimpleEmployeeAccountingSystem
{
    public enum EmployeeUpdateCommandType : byte
    {
        Exit = 0,
        UpdateName,
        UpdateAge,
        UpdatePost,
        EmployeeUpdateOptions,
    }
}