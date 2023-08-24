export function Container(children: any) {
    return (
        <div className='backdrop-blur-sm bg-black/10 rounded-br-[20px] p-5'>
            {children}
        </div>
    );
}