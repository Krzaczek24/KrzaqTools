# Specifiable v1.0.0

## English
This `Specifiable` class allows you to box any other class and keep information about that if object was specified or not.
You can use that boxing when you want to know if object was made null intentionally.

It works little bit like `Nullable`, it also have property `Value`, but it also have property `IsSpecified` which initially is set to `false`.
Setting any value, even `null`, sets property `IsSpecified` to `true`.
There is also available method `Unspecify`, just in case to clear `Value` using `default` value and setting `IsSpecified` again to `false`.
Class provides possibility comparing with any other `Specifiable<T>` and `Specifiable`.

### Changelog
#### v1.0.0
Library creation
#### v1.0.1
Fixed README

## Polski
Klasa `Specifiable` pozwala opakować każdą inną klasę i przechowywać informację o tym czy obiekt był określony czy też nie.
Możesz użyć tego opakowania jeśli chcesz wiedzieć czy obiekt został wyczyszczony intencjonalnie.

Działą to trochę jak `Nullable`, rónież posiada właściwość `Value`, ale posiada rónież właściwość `IsSpecified` która wstępnie ustawiona jest na `false`.
Ustawienie jakiejkolwiek wartości, nawet `null`-a, ustawia właściwość `IsSpecified` na `true`.
Dostępna jest również metoda `Unspecify`, na wypadek potrzeby wyczyszczenia `Value` ustawiając wartość `default` i ustawiając `IsSpecified` ponownien na `false`.
Klasa dostarcza możliwość porównywania z innymi `Specifiable<T>` oraz `Specifiable`.

### Zmiany
#### v1.0.0
Utworzenie biblioteki
#### v1.0.1
Naprawiono README
