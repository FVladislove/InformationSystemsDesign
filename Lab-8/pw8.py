from sys import orig_argv


def main():
    N = 12
    X = list(range(-11, 1, 1))
    print(f"X\t=> {X}")

    X_squared = [x ** 2 for x in X]
    print("X^2\t=> {X_squared}")

    Ya = [120, 170, 240, 290, 190, 170, 310, 430, 400, 260, 250, 300]
    print(f"Ya\t=> {Ya}")

    XYa = [x[0] * x[1] for x in zip(X, Ya)]
    print(f"XYa\t=> {XYa}")

    Yc = [180, 140, 110, 110, 130, 200, 210, 100, 50, 50, 90, 120]
    print(f"Yc\t=> {Yc}")

    XYc = [x[0] * x[1] for x in zip(X, Yc)]
    print(f"XYc\t=> {XYc}")

    b_A = b(N, X, Ya, XYa, X_squared)
    print(f"b for A\t=> {b_A}")
    print(f"a for A\t=> {a(N, Ya, X, b_A)}")

    b_C = b(N, X, Yc, XYc, X_squared)
    print(f"b for C\t=> {b_C}")
    print(f"a for C\t=> {a(N, Yc, X, b_C)}")


def b(N, X, Y, XY, X_squared):
    return (N * sum(XY) - sum(Y) * sum(X)) / (N * sum(X_squared) - sum(X) ** 2)


def a(N, Y, X, b):
    return (sum(Y) - b * sum(X)) / N


main()
