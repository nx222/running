internal class OperatorOption<T>
{
    protected T _value;

    public T Value { get => _value; }

    public OperatorOption(T value) { _value = value; }
}
