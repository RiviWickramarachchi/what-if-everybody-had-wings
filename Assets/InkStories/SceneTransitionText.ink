#speed:100
VAR dayVal = 0
{ 
 -dayVal == 1: -> day_1
  -else:
  {dayVal == 2: -> day_2 | -> day_3}
}

=== day_1 ===
Day One : As the first rays of sunlight gently caress your eyelids, you awaken to the familiar symphony of a normal day in your humble abode.
The soft hum of the refrigerator, the distant chirping of birds outside, and the comforting scent of fresh coffee brewing - the world comes alive… 
What’s on today’s to-do list? 
Lets find out! 

->END
=== day_2 ===
As the dawn's golden light seeps through the window, you stir from slumber, only to find a surreal sight greeting you.
Everyone gracefully soars on feathered wings, you alone stand grounded, some kind of anomaly…
->END

=== day_3 ===
Subtle transformations unfurl around you. Streets are reshaped, accommodating the new rhythm daily life has taken on. 
On your journey to work, an eerie stillness governs the roads - no traffic in sight. Windows all over hang open as winged commuters forgo the hassle of stairs and elevators to reach their destination. 
With the buses standing still, your chances of arriving to work on time are rapidly dwindling.

->END