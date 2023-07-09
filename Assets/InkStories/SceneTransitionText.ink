#speed:100
VAR dayVal = 0
{ 
 -dayVal == 1: -> day_1
  -else:
  {dayVal == 2: -> day_2 | -> day_3}
}

=== day_1 ===
This is day 1... Aasdasdasdasda. asdasdasdaisdbasdasdoasidnasdoasdkansd sad
->END
=== day_2 ===
This is day 2... Aasdasdasdasda.
->END

=== day_3 ===
This is day 3... Aasdasdasdasda.
->END