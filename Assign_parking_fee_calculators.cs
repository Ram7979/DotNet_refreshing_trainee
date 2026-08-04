using System;
using System.Collections.Generic;

class ParkingFeeCalculator
{
    static void Main()
    {
        Console.WriteLine("=== PARKING FEE CALCULATOR ===\n");

        // Sample data: VehicleType, Hours
        List<(char, double)> parkingRecords = new List<(char, double)>
        {
            ('C', 2.5),   // Car, 2.5 hours
            ('C', 12.0),  // Car, 12 hours
            ('M', 4.0),   // Motorcycle, 4 hours
            ('T', 6.5),   // Truck, 6.5 hours
            ('C', 0.25),  // Car, 15 minutes (free)
            ('M', 10.0)   // Motorcycle, 10 hours
        };

        foreach (var record in parkingRecords)
        {
            CalculateAndDisplayFee(record.Item1, record.Item2);
            Console.WriteLine("------------------------");
        }
    }

    static void CalculateAndDisplayFee(char vehicleType, double hours)
    {
        double hourlyRate = GetHourlyRate(vehicleType);
        double dailyMax = GetDailyMaximum(vehicleType);
        string vehicleName = GetVehicleName(vehicleType);

        double fee = CalculateParkingFee(hours, hourlyRate, dailyMax);

        Console.WriteLine($"Vehicle: {vehicleName}");
        Console.WriteLine($"Parking Duration: {hours:F2} hours");
        Console.WriteLine($"Hourly Rate: ${hourlyRate:F2}");
        Console.WriteLine($"Daily Maximum: ${dailyMax:F2}");
        Console.WriteLine($"Total Fee: ${fee:F2}");
    }

    static double CalculateParkingFee(double hours, double hourlyRate, double dailyMax)
    {
        // First 30 minutes free
        if (hours <= 0.5)
            return 0.0;

        // Remove first 30 minutes
        double chargeableHours = hours - 0.5;

        // Base fee
        double fee = chargeableHours * hourlyRate;

        // Apply daily maximum
        if (fee > dailyMax)
            fee = dailyMax;

        // Apply 10% discount if parked more than 8 hours
        if (hours > 8)
            fee *= 0.90;

        return fee;
    }

    static double GetHourlyRate(char vehicleType)
    {
        return Char.ToUpper(vehicleType) switch
        {
            'C' => 3.00,
            'M' => 2.00,
            'T' => 5.00,
            _ => 0.00
        };
    }

    static double GetDailyMaximum(char vehicleType)
    {
        return Char.ToUpper(vehicleType) switch
        {
            'C' => 25.00,
            'M' => 15.00,
            'T' => 40.00,
            _ => 0.00
        };
    }

    static string GetVehicleName(char vehicleType)
    {
        return Char.ToUpper(vehicleType) switch
        {
            'C' => "Car",
            'M' => "Motorcycle",
            'T' => "Truck",
            _ => "Unknown"
        };
    }
}