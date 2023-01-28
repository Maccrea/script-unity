public float kecepatan, scaleX, lompat, maxtinggi;
public KeyCode keyKanan = KeyCode.RightArrow, KeyCode keyKiri = KeyCode.LeftArrow, KeyCode keyLompat = KeyCode.UpArrow;
Rigidbody2D rb;
transform tr;

void Start()
{
    scaleX = transform.localScale.x;

    tr = GetComponent<transform>();
    rb = GetComponent<Rigidbody2D>();
}

void jalan_kiri()
{
    transform.localScale = new Vector3(-scaleX, transform.localScale.y,transform.localScale.z);
    transform.Translate(Vector3.left * kecepatan * Time.fixedDeltaTime,Space.Self)
}

void jalan_kanan()
{
    transform.localScale = new Vector3(scaleX,transform.localScale.y, transform.localScale.z);
    transform.Translate(Vector3.right * kecepatan* Time.fixedDeltaTime, Space.Self);
}

void melompat()
{
    GetComponent<Rigidbody2D>().velocity = new.Vector2(0, lompat);
}

void update()
{
    if (Input.GetKey(keyKiri))
    {
        jalan_kiri
    }
    else if (Input.GetKey(keyKanan))
    {
        jalan_kanan
    }
    if (Input.GetKeyDown(keyLompat)&& tr.position.y < maxtinggi)
    {
        melompat();
    }
}