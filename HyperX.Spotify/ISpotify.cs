namespace HyperX.Spotify;

public interface ISpotify : 
    INotification;

public interface ISpotify<T> :
    ISpotify;