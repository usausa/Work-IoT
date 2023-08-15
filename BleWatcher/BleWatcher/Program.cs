using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;

var watcher = new BluetoothLEAdvertisementWatcher
{
    ScanningMode = BluetoothLEScanningMode.Passive
};
watcher.Received += async (_, eventArgs) =>
{
    var device = await BluetoothLEDevice.FromBluetoothAddressAsync(eventArgs.BluetoothAddress);
    Console.WriteLine($"{eventArgs.Timestamp:HH:mm:ss.fff} {eventArgs.BluetoothAddress:X12} {eventArgs.RawSignalStrengthInDBm} {device?.Name}");
};

watcher.Start();

Console.ReadLine();
