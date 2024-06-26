﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive.Disposables;

namespace HyperX;
public partial class ObservableCollectionViewModel<TViewModel> :
    ObservableObject,
    IObservableCollectionViewModel<TViewModel>,
    IInitializer,
    IActivated,
    IDeactivating,
    IDeactivated,
    IDeactivatable,
    IList<TViewModel>,
    IList,
    IReadOnlyList<TViewModel>,
    INotifyCollectionChanged,
    INotificationHandler<Remove<TViewModel>>,
    INotificationHandler<Create<TViewModel>>,
    INotificationHandler<Insert<TViewModel>>,
    INotificationHandler<Move<TViewModel>>,
    INotificationHandler<Replace<TViewModel>>
    where TViewModel : 
    notnull
{
    private readonly ObservableCollection<TViewModel> collection = [];

    [ObservableProperty]
    private bool isInitialized;

    public ObservableCollectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer)
    {
        ServiceProvider = serviceProvider;
        ServiceFactory = serviceFactory;
        Publisher = publisher;
        Disposer = disposer;

        subscriber.Add(this);

        collection.CollectionChanged += OnCollectionChanged;
    }

    public ObservableCollectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IEnumerable<TViewModel> items)
    {
        ServiceProvider = serviceProvider;
        ServiceFactory = serviceFactory;
        Publisher = publisher;
        Disposer = disposer;

        subscriber.Add(this);

        collection.CollectionChanged += OnCollectionChanged;
        AddRange(items);
    }

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public event EventHandler? DeactivateHandler;

    public int Count => collection.Count;

    public IDisposer Disposer { get; private set; }

    bool IList.IsFixedSize => false;

    bool ICollection<TViewModel>.IsReadOnly => false;

    bool IList.IsReadOnly => false;

    bool ICollection.IsSynchronized => false;

    public IPublisher Publisher { get; private set; }

    public IServiceFactory ServiceFactory { get; private set; }

    public IServiceProvider ServiceProvider { get; private set; }

    object ICollection.SyncRoot => this;

    public TViewModel this[int index]
    {
        get => collection[index];
        set => SetItem(index, value);
    }

    object? IList.this[int index]
    {
        get => collection[index];
        set
        {
            TViewModel? item = default;

            try
            {
                item = (TViewModel)value!;
            }
            catch (InvalidCastException)
            {

            }

            this[index] = item!;
        }
    }

    public virtual Task Activated() =>
        Task.CompletedTask;

    public TViewModel Add()
    {
        TViewModel? item = ServiceFactory.Create<TViewModel>();

        Add(item);
        return item;
    }

    public TViewModel Add<T>(params object?[] parameters)
        where T : TViewModel
    {
        T? item = ServiceFactory.Create<T>(parameters);
        Add(item);

        return item;
    }

    public TViewModel Add<T>()
        where T :
        TViewModel
    {
        T? item = ServiceFactory.Create<T>();
        Add(item);

        return item;
    }

    public void Add(TViewModel item)
    {
        int index = collection.Count;
        InsertItem(index, item);
    }

    public void Add(object item)
    {
        int index = collection.Count;
        InsertItem(index, (TViewModel)item);
    }

    int IList.Add(object? value)
    {
        TViewModel? item = default;

        try
        {
            item = (TViewModel)value!;
        }
        catch (InvalidCastException)
        {

        }

        Add(item!);
        return Count - 1;
    }

    public void AddRange(IEnumerable<TViewModel> items)
    {
        foreach (TViewModel? item in items)
        {
            Add(item);
        }
    }

    public void Clear()
    {
        foreach (TViewModel item in collection)
        {
            Disposer.Dispose(item);
        }

        ClearItems();
    }

    public bool Contains(TViewModel item) =>
        collection.Contains(item);

    bool IList.Contains(object? value) =>
        IsCompatibleObject(value) && Contains((TViewModel)value!);

    public void CopyTo(TViewModel[] array, int index) =>
        collection.CopyTo(array, index);

    void ICollection.CopyTo(Array array, int index) =>
        collection.CopyTo((TViewModel[])array, index);

    public Task Deactivate()
    {
        DeactivateHandler?.Invoke(this, new EventArgs());
        return Task.CompletedTask;
    }

    public virtual Task Deactivated() =>
        Task.CompletedTask;

    public virtual Task Deactivating() =>
        Task.CompletedTask;

    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
        Disposer.Dispose(this);
    }

    public IEnumerator<TViewModel> GetEnumerator() =>
        collection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        ((IEnumerable)collection).GetEnumerator();

    public Task Handle(Remove<TViewModel> args,
        CancellationToken cancellationToken)
    {
        foreach (TViewModel item in this.ToList())
        {
            if (args.Value is not null && args.Value.Equals(item))
            {
                Remove(item);
            }
        }

        return Task.CompletedTask;
    }

    public Task Handle(Create<TViewModel> args,
        CancellationToken cancellationToken)
    {
        if (args.Value is TViewModel item)
        {
            Add(item);
        }

        return Task.CompletedTask;
    }

    public Task Handle(Insert<TViewModel> args,
        CancellationToken cancellationToken)
    {
        if (args.Value is TViewModel item)
        {
            Insert(args.Index, item);
        }

        return Task.CompletedTask;
    }

    public Task Handle(Move<TViewModel> args,
        CancellationToken cancellationToken)
    {
        if (args.Value is TViewModel item)
        {
            Move(args.Index, item);
        }

        return Task.CompletedTask;
    }

    public Task Handle(Replace<TViewModel> args, 
        CancellationToken cancellationToken)
    {
        if (args.Value is TViewModel item)
        {
            Replace(args.Index, item);
        }

        return Task.CompletedTask;
    }

    public int IndexOf(TViewModel item) =>
        collection.IndexOf(item);

    int IList.IndexOf(object? value) =>
        IsCompatibleObject(value) ?
        IndexOf((TViewModel)value!) : -1;

    public async Task Initialize()
    {
        if (isInitialized)
        {
            return;
        }

        isInitialized = true;

        object? key = this.GetAttribute<NotificationAttribute>()
            is NotificationAttribute attribute
            ? this.GetPropertyValue(() => attribute.Key) is { } value ? value : attribute.Key
            : null;

        await Publisher.PublishUI(new Enumerate<TViewModel>(key));
    }

    public void Insert(int index, TViewModel item) =>
        InsertItem(index, item);

    void IList.Insert(int index,
        object? value)
    {
        if (value is TViewModel item)
        {
            Insert(index, item);
        }
    }

    public bool Move(int index, TViewModel item)
    {
        int oldIndex = collection.IndexOf(item);
        if (oldIndex < 0)
        {
            return false;
        }

        RemoveItem(oldIndex);
        Insert(index, item);

        return true;
    }

    public bool Remove(TViewModel item)
    {
        int index = collection.IndexOf(item);
        if (index < 0)
        {
            return false;
        }

        Disposer.Dispose(item);
        RemoveItem(index);

        return true;
    }

    void IList.Remove(object? value)
    {
        if (IsCompatibleObject(value))
        {
            Remove((TViewModel)value!);
        }
    }

    public void RemoveAt(int index) =>
        RemoveItem(index);

    public bool Replace(int index, 
        TViewModel item)
    {
        if (index <= Count - 1)
        {
            RemoveItem(index);
        }
        else
        {
            index = Count;
        }

        Insert(index, item);
        return true;
    }

    protected virtual void ClearItems() =>
        collection.Clear();

    protected virtual void InsertItem(int index,
        TViewModel item)
    {
        Disposer.Add(this, item);
        Disposer.Add(item, item, Disposable.Create(() =>
        {
            if (item is IList collection)
            {
                collection.Clear();
            }
        }));

        collection.Insert(index, item);
    }

    protected virtual void RemoveItem(int index) =>
        collection.RemoveAt(index);

    protected virtual void SetItem(int index, TViewModel item) =>
        collection[index] = item;

    private static bool IsCompatibleObject(object? value) =>
        (value is TViewModel) || (value == null && default(TViewModel) == null);

    private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args) => 
        CollectionChanged?.Invoke(this, args);
}

public class ObservableCollectionViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory, 
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ObservableCollectionViewModel<IDisposable>(serviceProvider, serviceFactory, publisher, subscriber, disposer);