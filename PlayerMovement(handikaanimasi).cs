public float kecepatan, scaleX, lompat, maxtinggi;
private Animator animator;

public KeyCode keyKanan = KeyCode.RightArrow, KeyCode keyKiri = KeyCode.LeftArrow, KeyCode keyLompat = KeyCode.UpArrow;
Rigidbody2D rb;
transform tr;

void Start()
{
    scaleX = transform.localScale.x;

    animator = GetComponent<Animator>();
    tr = GetComponent<transform>();
    rb = GetComponent<Rigidbody2D>();
}

void jalan_kiri()
{
    transform.localScale = new Vector3(-scaleX, transform.localScale.y,transform.localScale.z);
    transform.Translate(Vector3.left * kecepatan * Time.fixedDeltaTime,Space.Self)
    animator.SetBool("run", true);
}

void jalan_kanan()
{
    transform.localScale = new Vector3(scaleX,transform.localScale.y, transform.localScale.z);
    transform.Translate(Vector3.right * kecepatan* Time.fixedDeltaTime, Space.Self);
    animator.SetBool("IsRun", true);
}

void berhenti()
{
    animator.SetBool("IsRun", false);
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
    if (Input.GetKeyDown(keyLompat) && rb.velocity.y == 0)
    {
        melompat();
    }

    else if(Input.GetKeyUp(keyKiri) || Input.GetKeyUp(keyKanan))
    {
        berhenti();
    }
}